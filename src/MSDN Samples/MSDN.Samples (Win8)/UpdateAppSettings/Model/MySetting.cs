namespace MSDN.Samples.UpdateAppSettings.Model
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;

    using MSDN.Samples.Annotations;

    public class MySetting : INotifyPropertyChanged
    {
        private int _value;

        public event PropertyChangedEventHandler PropertyChanged;

        public int Value
        {
            get
            {
                return this._value;
            }
            set
            {
                this._value = value; this.OnPropertyChanged();
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = this.PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}