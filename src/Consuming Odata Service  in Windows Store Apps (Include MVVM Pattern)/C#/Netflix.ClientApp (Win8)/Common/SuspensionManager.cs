// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SuspensionManager.cs" company="saramgsilva">
//   Copyright (c) 2012 saramgsilva. All rights reserved.
// </copyright>
// <summary>
//   SuspensionManager captures global session state to simplify process lifetime management
//   for an application.  Note that session state will be automatically cleared under a variety
//   of conditions and should only be used to store information that would be convenient to
//   carry across sessions, but that should be discarded when an application crashes or is
//   upgraded.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Netflix.ClientApp.Common
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;
    using System.IO;
    using System.Runtime.Serialization;
    using System.Threading.Tasks;

    using Windows.Storage;
    using Windows.Storage.Streams;
    using Windows.UI.Xaml;
    using Windows.UI.Xaml.Controls;

    /// <summary>
    /// SuspensionManager captures global session state to simplify process lifetime management
    /// for an application.  Note that session state will be automatically cleared under a variety
    /// of conditions and should only be used to store information that would be convenient to
    /// carry across sessions, but that should be discarded when an application crashes or is
    /// upgraded.
    /// </summary>
    [SuppressMessage("StyleCop.CSharp.MaintainabilityRules", "SA1402:FileMayOnlyContainASingleClass", Justification = "Reviewed. Suppression is OK here.")]
    internal sealed class SuspensionManager
    {
        #region Constants

        /// <summary>
        /// The session state filename.
        /// </summary>
        private const string SessionStateFilename = "_sessionState.xml";

        #endregion Constants

        #region Static Fields

        /// <summary>
        /// The _known types.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.NamingRules", "SA1311:StaticReadonlyFieldsMustBeginWithUpperCaseLetter", Justification = "Reviewed. Suppression is OK here.")]
        private static readonly List<Type> _knownTypes = new List<Type>();

        /// <summary>
        /// The frame session state key property.
        /// </summary>
        private static readonly DependencyProperty FrameSessionStateKeyProperty =
            DependencyProperty.RegisterAttached(
                "_FrameSessionStateKey", typeof(string), typeof(SuspensionManager), null);

        /// <summary>
        /// The frame session state property.
        /// </summary>
        private static readonly DependencyProperty FrameSessionStateProperty =
            DependencyProperty.RegisterAttached(
                "_FrameSessionState", typeof(Dictionary<string, object>), typeof(SuspensionManager), null);

        /// <summary>
        /// The _registered frames.
        /// </summary>
        private static readonly List<WeakReference<Frame>> RegisteredFrames = new List<WeakReference<Frame>>();

        /// <summary>
        /// The _session state.
        /// </summary>
        private static Dictionary<string, object> sessionState = new Dictionary<string, object>();

        #endregion Static Fields

        #region Public Properties

        /// <summary>
        /// Gets or sets the list of custom types provided to the <see cref="DataContractSerializer"/> when
        /// reading and writing session state.  Initially empty, additional types may be
        /// added to customize the serialization process.
        /// </summary>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1624:PropertySummaryDocumentationMustOmitSetAccessorWithRestrictedAccess", Justification = "Reviewed. Suppression is OK here.")]
        public static List<Type> KnownTypes
        {
            get
            {
                return _knownTypes;
            }
        }

        /// <summary>
        /// Gets the provides access to global session state for the current session.  This state is
        /// serialized by <see cref="SaveAsync"/> and restored by
        /// <see cref="RestoreAsync"/>, so values must be serializable by
        /// <see cref="DataContractSerializer"/> and should be as compact as possible.  Strings
        /// and other self-contained data types are strongly recommended.
        /// </summary>
        public static Dictionary<string, object> SessionState
        {
            get
            {
                return sessionState;
            }
        }

        #endregion Public Properties

        #region Public Methods and Operators

        /// <summary>
        /// Registers a <see cref="Frame"/> instance to allow its navigation history to be saved to
        /// and restored from <see cref="SessionState"/>.  Frames should be registered once
        /// immediately after creation if they will participate in session state management.  Upon
        /// registration if state has already been restored for the specified key
        /// the navigation history will immediately be restored.  Subsequent invocations of
        /// <see cref="RestoreAsync"/> will also restore navigation history.
        /// </summary>
        /// <param name="frame">
        /// An instance whose navigation history should be managed by
        /// <see cref="SuspensionManager"/>
        /// </param>
        /// <param name="sessionStateKey">
        /// A unique key into <see cref="SessionState"/> used to
        /// store navigation-related information.
        /// </param>
        public static void RegisterFrame(Frame frame, string sessionStateKey)
        {
            if (frame.GetValue(FrameSessionStateKeyProperty) != null)
            {
                throw new InvalidOperationException("Frames can only be registered to one session state key");
            }

            if (frame.GetValue(FrameSessionStateProperty) != null)
            {
                throw new InvalidOperationException(
                    "Frames must be either be registered before accessing frame session state, or not registered at all");
            }

            // Use a dependency property to associate the session key with a frame, and keep a list of frames whose
            // navigation state should be managed
            frame.SetValue(FrameSessionStateKeyProperty, sessionStateKey);
            RegisteredFrames.Add(new WeakReference<Frame>(frame));

            // Check to see if navigation state can be restored
            RestoreFrameNavigationState(frame);
        }

        /// <summary>
        /// Restores previously saved <see cref="SessionState"/>.  Any <see cref="Frame"/> instances
        /// registered with <see cref="RegisterFrame"/> will also restore their prior navigation
        /// state, which in turn gives their active <see cref="Page"/> an opportunity restore its
        /// state.
        /// </summary>
        /// <returns>An asynchronous task that reflects when session state has been read.  The
        /// content of <see cref="SessionState"/> should not be relied upon until this task
        /// completes.</returns>
        public static async Task RestoreAsync()
        {
            sessionState = new Dictionary<string, object>();

            try
            {
                // Get the input stream for the SessionState file
                StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync(SessionStateFilename);
                using (IInputStream inStream = await file.OpenSequentialReadAsync())
                {
                    // Deserialize the Session State
                    var serializer = new DataContractSerializer(typeof(Dictionary<string, object>), _knownTypes);
                    sessionState = (Dictionary<string, object>)serializer.ReadObject(inStream.AsStreamForRead());
                }

                // Restore any registered frames to their saved state
                foreach (var weakFrameReference in RegisteredFrames)
                {
                    Frame frame;
                    if (weakFrameReference.TryGetTarget(out frame))
                    {
                        frame.ClearValue(FrameSessionStateProperty);
                        RestoreFrameNavigationState(frame);
                    }
                }
            }
            catch (Exception e)
            {
                throw new SuspensionManagerException(e);
            }
        }

        /// <summary>
        /// Save the current <see cref="SessionState"/>.  Any <see cref="Frame"/> instances
        /// registered with <see cref="RegisterFrame"/> will also preserve their current
        /// navigation stack, which in turn gives their active <see cref="Page"/> an opportunity
        /// to save its state.
        /// </summary>
        /// <returns>An asynchronous task that reflects when session state has been saved.</returns>
        public static async Task SaveAsync()
        {
            try
            {
                // Save the navigation state for all registered frames
                foreach (var weakFrameReference in RegisteredFrames)
                {
                    Frame frame;
                    if (weakFrameReference.TryGetTarget(out frame))
                    {
                        SaveFrameNavigationState(frame);
                    }
                }

                // Serialize the session state synchronously to avoid asynchronous access to shared
                // state
                var sessionData = new MemoryStream();
                var serializer = new DataContractSerializer(typeof(Dictionary<string, object>), _knownTypes);
                serializer.WriteObject(sessionData, sessionState);

                // Get an output stream for the SessionState file and write the state asynchronously
                StorageFile file =
                    await
                    ApplicationData.Current.LocalFolder.CreateFileAsync(
                        SessionStateFilename, CreationCollisionOption.ReplaceExisting);
                using (Stream fileStream = await file.OpenStreamForWriteAsync())
                {
                    sessionData.Seek(0, SeekOrigin.Begin);
                    await sessionData.CopyToAsync(fileStream);
                    await fileStream.FlushAsync();
                }
            }
            catch (Exception e)
            {
                throw new SuspensionManagerException(e);
            }
        }

        /// <summary>
        /// Provides storage for session state associated with the specified <see cref="Frame"/>.
        /// Frames that have been previously registered with <see cref="RegisterFrame"/> have
        /// their session state saved and restored automatically as a part of the global
        /// <see cref="SessionState"/>.  Frames that are not registered have transient state
        /// that can still be useful when restoring pages that have been discarded from the
        /// navigation cache.
        /// </summary>
        /// <remarks>
        /// Apps may choose to rely on <see cref="LayoutAwarePage"/> to manage
        /// page-specific state instead of working with frame session state directly.
        /// </remarks>
        /// <param name="frame">
        /// The instance for which session state is desired.
        /// </param>
        /// <returns>
        /// A collection of state subject to the same serialization mechanism as
        /// <see cref="LayoutAwarePage"/>.
        /// </returns>
        public static Dictionary<string, object> SessionStateForFrame(Frame frame)
        {
            var frameState = (Dictionary<string, object>)frame.GetValue(FrameSessionStateProperty);

            if (frameState == null)
            {
                var frameSessionKey = (string)frame.GetValue(FrameSessionStateKeyProperty);
                if (frameSessionKey != null)
                {
                    // Registered frames reflect the corresponding session state
                    if (!sessionState.ContainsKey(frameSessionKey))
                    {
                        sessionState[frameSessionKey] = new Dictionary<string, object>();
                    }

                    frameState = (Dictionary<string, object>)sessionState[frameSessionKey];
                }
                else
                {
                    // Frames that aren't registered have transient state
                    frameState = new Dictionary<string, object>();
                }

                frame.SetValue(FrameSessionStateProperty, frameState);
            }

            return frameState;
        }

        /// <summary>
        /// Disassociates a <see cref="Frame"/> previously registered by <see cref="RegisterFrame"/>
        /// from <see cref="SessionState"/>.  Any navigation state previously captured will be
        /// removed.
        /// </summary>
        /// <param name="frame">
        /// An instance whose navigation history should no longer be
        /// managed.
        /// </param>
        public static void UnregisterFrame(Frame frame)
        {
            // Remove session state and remove the frame from the list of frames whose navigation
            // state will be saved (along with any weak references that are no longer reachable)
            SessionState.Remove((string)frame.GetValue(FrameSessionStateKeyProperty));
            RegisteredFrames.RemoveAll(
                (weakFrameReference) =>
                {
                    Frame testFrame;
                    return !weakFrameReference.TryGetTarget(out testFrame) || testFrame == frame;
                });
        }

        #endregion Public Methods and Operators

        #region Methods

        /// <summary>
        /// The restore frame navigation state.
        /// </summary>
        /// <param name="frame">
        /// The frame.
        /// </param>
        private static void RestoreFrameNavigationState(Frame frame)
        {
            Dictionary<string, object> frameState = SessionStateForFrame(frame);
            if (frameState.ContainsKey("Navigation"))
            {
                frame.SetNavigationState((string)frameState["Navigation"]);
            }
        }

        /// <summary>
        /// The save frame navigation state.
        /// </summary>
        /// <param name="frame">
        /// The frame.
        /// </param>
        private static void SaveFrameNavigationState(Frame frame)
        {
            Dictionary<string, object> frameState = SessionStateForFrame(frame);
            frameState["Navigation"] = frame.GetNavigationState();
        }

        #endregion Methods
    }
}