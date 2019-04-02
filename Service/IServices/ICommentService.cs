using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using ServicePattern;

namespace Service.IServices
{
    public interface ICommentService : IService<Comment>
    {
         List<Comment> BlogComment(int id);
    }
}
