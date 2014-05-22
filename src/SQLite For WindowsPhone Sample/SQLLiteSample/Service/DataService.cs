namespace SQLLiteSample.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using SQLite;

    using SQLLiteSample.Model;

    /// <summary>
    /// The data service
    /// </summary>
    public class DataService : IDataService
    {
        /// <summary>
        /// Creates the DB.
        /// </summary>
        public static async void CreateDbAsync()
        {
            App.Connection = new SQLiteAsyncConnection("UniversityDB.db");

            var universityTask = App.Connection.CreateTableAsync<University>();
            var studentTask = App.Connection.CreateTableAsync<Student>();

            await Task.WhenAll(new Task[] { universityTask, studentTask });
        }

        /// <summary>
        /// Deletes the student.
        /// </summary>
        /// <param name="selectedStudent">The selected student.</param>
        /// <returns>The <see cref="Task" />.</returns>
        public async Task DeleteStudentAsync(Student selectedStudent)
        {
            await App.Connection.DeleteAsync(selectedStudent);
        }

        /// <summary>
        /// Deletes the university.
        /// </summary>
        /// <param name="selectedUniversity">The selected university.</param>
        /// <returns>The <see cref="Task" />.</returns>
        public async Task DeleteUniversityAsync(University selectedUniversity)
        {
            var students = await LoadStudentsByUniversityAsync(selectedUniversity);
            await App.Connection.RunInTransactionAsync(async (SQLiteConnection connection) =>
            {
                foreach (var student in students)
                {
                    DeleteStudentAsync(student);
                }

                App.Connection.DeleteAsync(selectedUniversity);
            }); 
        }

        /// <summary>
        /// Loads the studentby id.
        /// </summary>
        /// <param name="guid">The GUID.</param>
        /// <returns></returns>
        /// <exception cref="System.Exception">Student not found.</exception>
        public async Task<Student> LoadStudentbyIdAsync(string guid)
        {
            var result = await App.Connection.QueryAsync<Student>(string.Format("select * from Student where Id='{0}'", guid));
            return result.FirstOrDefault();
        }
        
        /// <summary>
        /// The load student.
        /// </summary>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        public async Task<IList<Student>> LoadStudentsAsync()
        {
            return await App.Connection.Table<Student>().ToListAsync();
        }
        
        /// <summary>
        /// Loads the students by university.
        /// </summary>
        /// <param name="university">The university.</param>
        /// <returns></returns>
        public async Task<IList<Student>> LoadStudentsByUniversityAsync(University university)
        {
            return await LoadStudentsByUniversityAsync(university.Id);
        }

        /// <summary>
        /// The load university.
        /// </summary>
        /// <returns>
        /// The <see cref="Task"/>.
        /// </returns>
        public async Task<IList<University>> LoadUniversitiesAsync()
        {
            return await App.Connection.Table<University>().ToListAsync();
        }

        /// <summary>
        /// The load university by id.
        /// </summary>
        /// <param name="guid">
        /// The guid.
        /// </param>
        /// <returns>
        /// The <see cref="University"/>.
        /// </returns>
        /// <exception cref="Exception">
        /// </exception>
        public async Task<University> LoadUniversityByIdAsync(string guid)
        {
            var result = await App.Connection.QueryAsync<University>(string.Format("select * from University where Id='{0}'", guid));
            return result.FirstOrDefault();
        }

        /// <summary>
        /// The save student.
        /// </summary>
        /// <param name="newStudent">The new student.</param>
        /// <returns>
        /// The <see cref="Task" />.
        /// </returns>
        public async Task SaveStudentAsync(Student newStudent)
        {
            await App.Connection.InsertAsync(newStudent);
        }

        /// <summary>
        /// Saves the university.
        /// </summary>
        /// <param name="newUniversity">The new university.</param>
        /// <returns>The <see cref="Task" />.</returns>
        public async Task SaveUniversityAsync(University newUniversity)
        {
            await App.Connection.InsertAsync(newUniversity);
        }

        /// <summary>
        /// Updates the student.
        /// </summary>
        /// <param name="selectedStudent">The selected student.</param>
        /// <returns>The <see cref="Task" />.</returns>
        public async Task UpdateStudentAsync(Student selectedStudent)
        {
            var existingContact = await App.Connection.FindAsync<Student>(s => s.Id == selectedStudent.Id);
            if (existingContact != null)
            {
                await App.Connection.UpdateAsync(selectedStudent);
            }
        }

        /// <summary>
        /// Updates the university.
        /// </summary>
        /// <param name="selectedUniversity">The selected university.</param>
        /// <returns>The <see cref="Task" />.</returns>
        public async Task UpdateUniversityAsync(University selectedUniversity)
        {
            var existingContact = await App.Connection.FindAsync<University>(u => u.Id == selectedUniversity.Id);
            if (existingContact != null)
            {
                await App.Connection.UpdateAsync(selectedUniversity);
            }
        }

        /// <summary>
        /// The load student by university.
        /// </summary>
        /// <param name="guid">
        /// The guid.
        /// </param>
        /// <returns>
        /// The <see cref="IList"/>.
        /// </returns>
        public async Task<IList<Student>> LoadStudentsByUniversityAsync(Guid guid)
        {
            var result = await App.Connection.QueryAsync<Student>(string.Format("select * from Student where UniversityId='{0}'", guid));
            return result.ToList();
        }
    }
}
