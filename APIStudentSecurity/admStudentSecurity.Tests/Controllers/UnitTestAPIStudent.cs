using System;
using APIStudentSecurity.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace admStudentSecurity.Tests.Controllers
{
    [TestClass]
    public class UnitTestAPIStudent
    {
        [TestMethod]
        public void TestGetStudent ()
        {
            //Arrange 
            StudentsController studentsController = new StudentsController();  //objeto

            //Act
            var listaEstudiantes = studentsController.GetStudents();

            //Assert
            Assert.IsNotNull(listaEstudiantes);
        }
    }
}
