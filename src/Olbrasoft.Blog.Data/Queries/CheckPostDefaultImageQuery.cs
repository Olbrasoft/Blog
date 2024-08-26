using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Olbrasoft.Blog.Data.Queries;
public class CheckPostDefaultImageQuery : BaseQuery<bool>
{
    public CheckPostDefaultImageQuery(IMediator mediator) : base(mediator)
    {
    }

    public CheckPostDefaultImageQuery(IQueryProcessor processor) : base(processor)
    {
    }

    public int PostId { get; set; }
    public string DefaultImageFileNameAndExtension { get; set; } = string.Empty; 

}
