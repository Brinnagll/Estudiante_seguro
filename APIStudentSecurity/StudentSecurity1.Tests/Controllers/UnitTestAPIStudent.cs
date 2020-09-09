using System;
using APIStudentSecurity.Controllers;
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
    }
}
