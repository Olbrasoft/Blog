using System.Linq;

namespace Olbrasoft.Blog.Data.Entities;

public class CreationInfoTest
{
    [Fact]
    public void Is_Abstract()
    {
        //Arrange
        var type = typeof(CreationInfo);

        //Act
        var isAbstract = type.IsAbstract;

        //Assert
        Assert.True(isAbstract);
    }

    //[Fact]
    //public void CreationInfo_Implement_Interface_ICreatorInfo()
    //{
    //    //Arrange
    //    var type = typeof(CreationInfo);

    //    //Act
    //    var result = type.GetInterfaces().Where(p=>p.Name== nameof(ICreatorInfo<BlogUser>));

    //    //Assert
    //    Assert.True(result.Count() == 1);
    //}


    [Fact]
    public void Implement_Interface_IHaveCreated()
    {
        //Arrange
        var type = typeof(CreationInfo);

        //Act
        var result = type.GetInterfaces().Where(p => p.Name == nameof(IHaveCreated));

        //Assert
        Assert.True(result.Count()==1);

    }



}
