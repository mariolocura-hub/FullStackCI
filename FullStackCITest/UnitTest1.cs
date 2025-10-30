using FullStackCI.Models;

namespace FullStackCITest
{

    public class UnitTest1
    {
        [Fact]//no tiene parametros
        public void Test1()
        {

            Category category = new Category();
            category.Id = 1;
            category.Name = "Ficción";
            category.Description = "Libros de ficción y literatura";
            Assert.NotNull(category);// Assert permite verificar que el valor no es nulo
            Assert.NotNull(category.Name);// Assert permite verificar que el valor no es nulo
            //Assert.Equal(3, category.Id);// Assert permite verificar que el valor es igual al esperado


        }
    }
}