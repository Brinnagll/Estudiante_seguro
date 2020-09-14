using System;
using System.Net;
using System.Web.Http;
using System.Web.Http.Results;
using APIStudentSecurity.Controllers;
using APIStudentSecurity.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace StudentSecurity1.Tests.Controllers
{
    [TestClass]
    public class UnitTestAPIStudent
    {
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange
            StudentsController studentsController = new StudentsController(); //objeto 

            //Act
            var listaEstudiantes = studentsController.GetStudents();


            //Assert
            Assert.IsNotNull(listaEstudiantes);
        }


        [TestMethod]
        public void TestPostStudent()
        {
            //Arrange
            StudentsController studentsController = new StudentsController();
            Student estudiante_esperado = new Student()
            {
                FirstName = "Martinez",
                LastName = "Alfalfa",
                StudentID = 1,
                EnrollmentDate = DateTime.Today
            };

            //Act
            IHttpActionResult actionResult = studentsController.PostStudent(estudiante_esperado);
            var estudiante_actual = actionResult as CreatedAtRouteNegotiatedContentResult<Student>;

            //Assert
            Assert.IsNotNull(estudiante_actual);
            Assert.AreEqual("DefaultApi", estudiante_actual.RouteName);
            Assert.AreEqual(estudiante_esperado.StudentID, estudiante_actual.RouteValues["id"]);
            Assert.AreEqual(estudiante_esperado.FirstName, estudiante_actual.Content.FirstName);
            Assert.AreEqual(estudiante_esperado.LastName, estudiante_actual.Content.LastName);
        }

        [TestMethod]
        public void TestDeleteStudent()
        {
            //Arrange
            StudentsController studentsController = new StudentsController();
            Student estudiante_prueba = new Student()
            {
                FirstName = "Martinez",
                LastName = "Alfalfa",
                StudentID = 1,
                EnrollmentDate = DateTime.Now
            };

            //Act
            IHttpActionResult actionResult = studentsController.PostStudent(estudiante_prueba);
            IHttpActionResult actionResultDelete = studentsController.DeleteStudent(estudiante_prueba.StudentID);

            //Assert
            Assert.IsInstanceOfType(actionResultDelete, typeof(OkNegotiatedContentResult<Student>));

        }

        [TestMethod]
        public void TestPutStudent()
        {
            //Arrange
            StudentsController studentsController = new StudentsController();
            Student estudiante_esperado = new Student()
            {
                FirstName = "Martinez",
                LastName = "Alfalfa",
                StudentID = 1,
                EnrollmentDate = DateTime.Now
            };
            int ID = estudiante_esperado.StudentID; //si es nulo, innecesario
            string nuevo_nombre = "Tulio";

            //Act
            var actionResult = studentsController.PostStudent(estudiante_esperado);
            estudiante_esperado.FirstName = nuevo_nombre;
            var actionResultPut = studentsController.PutStudent(estudiante_esperado.StudentID, estudiante_esperado) as StatusCodeResult;

            //Assert
            Assert.IsNotNull(actionResultPut);
            Assert.AreEqual(HttpStatusCode.NoContent, actionResultPut.StatusCode);
            Assert.IsInstanceOfType(actionResultPut, typeof(StatusCodeResult));
        }
    }
}
