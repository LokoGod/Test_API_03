using Test_API_03.Models.DTO;

namespace Test_API_03.Data
{
    public static class TestStore
    {
        public static List<TestDTO> testList = new List<TestDTO>
        {
            new TestDTO {Id = 1, Name = "Kratos"},
            new TestDTO {Id = 2, Name = "Athena"}
        };
    }
}
