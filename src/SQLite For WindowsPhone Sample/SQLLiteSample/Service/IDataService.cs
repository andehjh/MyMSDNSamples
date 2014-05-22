namespace SQLLiteSample.Service
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using SQLLiteSample.Model;

    /// <summary>
    /// The data service interface
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Deletes the student.
        /// </summary>
        /// <param name="selectedStudent">The selected student.</param>
        /// <returns></returns>
        Task DeleteStudentAsync(Student selectedStudent);

        /// <summary>
        /// Deletes the university.
        /// </summary>
        /// <param name="selectedUniversity">The selected university.</param>
        /// <returns></returns>
        Task DeleteUniversityAsync(University selectedUniversity);

        /// <summary>
        /// Loads the studentby id.
        /// </summary>
        /// <param name="guid">The GUID.</param>
        /// <returns></returns>
        Task<Student> LoadStudentbyIdAsync(string guid);

        /// <summary>
        /// The load student.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task<IList<Student>> LoadStudentsAsync();

        /// <summary>
        /// Loads the students by university.
        /// </summary>
        /// <param name="University">The university.</param>
        /// <returns></returns>
        Task<IList<Student>> LoadStudentsByUniversityAsync(University University);
        
        /// <summary>
        /// Loads the university.
        /// </summary>
        /// <returns></returns>
        Task<IList<University>> LoadUniversitiesAsync();

        /// <summary>
        /// The load university by id.
        /// </summary>
        /// <param name="guid">
        /// The guid.
        /// </param>
        /// <returns>
        /// The <see cref="University"/>.
        /// </returns>
        Task<University> LoadUniversityByIdAsync(string guid);

        /// <summary>
        /// The save student.
        /// </summary>
        /// <param name="newStudent">
        /// The new student.
        /// </param>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        Task SaveStudentAsync(Student newStudent);

        /// <summary>
        /// Saves the university.
        /// </summary>
        /// <param name="newUniversity">The new university.</param>
        /// <returns></returns>
        Task SaveUniversityAsync(University newUniversity);

        /// <summary>
        /// Updates the student.
        /// </summary>
        /// <param name="selectedStudent">The selected student.</param>
        /// <returns></returns>
        Task UpdateStudentAsync(Student selectedStudent);

        /// <summary>
        /// Updates the university.
        /// </summary>
        /// <param name="selectedUniversity">The selected university.</param>
        /// <returns></returns>
        Task UpdateUniversityAsync(University selectedUniversity);

        /// <summary>
        /// Loads the students by university async.
        /// </summary>
        /// <param name="guid">The GUID.</param>
        /// <returns></returns>
        Task<IList<Student>> LoadStudentsByUniversityAsync(Guid guid);
    }
}
