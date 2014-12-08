using System;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using Kernel;

namespace Model.Test
{
    [TestClass]
    public class NoteRepositoryTest
    {
        [TestMethod]
        public void AddTestMethod()
        {
            IKernel kernel = new StandardKernel(new Kernel.Module());
            var repository = kernel.Get<INoteRepository>();

            var note = new Note() {
                Body = "Test body",
                CreateDate = DateTime.Now,
                Title = "Test title"
            };

            repository.Add(note);

            var noteFromBase = repository.GetAll()
                .FirstOrDefault(x => x.Title == "Test title");

            Assert.IsNotNull(noteFromBase);
        }
    }
}
