using Olbrasoft.Data.Cqrs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Olbrasoft.Blog.Data.Commands.CommentCommands;
public class NestedCommentDeleteCommandTest
{
    [Fact]
    public void NestedCommentDeleteCommand_Inherit_From_()
    {
        //Arrange
        var dm = new Mock<IDispatcher>();

        //Act
        var command = new NestedCommentDeleteCommand(dm.Object);

        //Assert
        Assert.IsAssignableFrom<ByIdAndCreatorIdRequest>(command);
    }
}
