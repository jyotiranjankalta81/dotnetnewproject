// // using System;
// // using System.Collections.Generic;
// // using System.Linq;
// // using System.Threading.Tasks;
// // using api.Dtos.Comment;
// // using api.Models;

// // namespace api.Mappers
// // {
// //     public static class CommentMapper
// //     {
// //         public static CommentDto ToCommentDto(this Comment commentModel)
// //         {
// //             return new CommentDto
// //             {
// //                 Id = commentModel.Id,
// //                 Title = commentModel.Title,
// //                 Content = commentModel.Content,
// //                 CreatedOn = commentModel.CreatedOn,
// //                 CreatedBy = commentModel.AppUser.UserName,
// //                 StockId = commentModel.StockId
// //             };
// //         }

// //         public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int stockId)
// //         {
// //             return new Comment
// //             {
// //                 Title = commentDto.Title,
// //                 Content = commentDto.Content,
// //                 StockId = stockId
// //             };
// //         }

// //         public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto, int stockId)
// //         {
// //             return new Comment
// //             {
// //                 Title = commentDto.Title,
// //                 Content = commentDto.Content,
// //                 StockId = stockId
// //             };
// //         }

// //     }
// // }



// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Threading.Tasks;
// using api.Dtos.Comment;
// using api.Models;

// namespace api.Mappers
// {
//     public static class CommentMapper
//     {
//         public static CommentDto ToCommentDto(this Comment commentModel)
//         {
//             if (commentModel == null)
//             {
//                 throw new ArgumentNullException(nameof(commentModel));
//             }

//             return new CommentDto
//             {
//                 Id = commentModel.Id,
//                 Title = commentModel.Title,
//                 Content = commentModel.Content,
//                 CreatedOn = commentModel.CreatedOn,
//                 CreatedBy = commentModel.AppUser?.UserName ?? string.Empty,
//                 StockId = commentModel.StockId
//             };
//         }

//         public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int stockId, AppUser appUser)
//         {
//             if (commentDto == null)
//             {
//                 throw new ArgumentNullException(nameof(commentDto));
//             }

//             if (appUser == null)
//             {
//                 throw new ArgumentNullException(nameof(appUser));
//             }

//             return new Comment
//             {
//                 Title = commentDto.Title,
//                 Content = commentDto.Content,
//                 StockId = stockId,
//                 AppUser = appUser
//             };
//         }

//         public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto, int stockId, AppUser appUser)
//         {
//             if (commentDto == null)
//             {
//                 throw new ArgumentNullException(nameof(commentDto));
//             }

//             if (appUser == null)
//             {
//                 throw new ArgumentNullException(nameof(appUser));
//             }

//             return new Comment
//             {
//                 Title = commentDto.Title,
//                 Content = commentDto.Content,
//                 StockId = stockId,
//                 AppUser = appUser
//             };
//         }
//     }
// }



using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;
using api.Models;

namespace api.Mappers
{
    public static class CommentMapper
    {
        public static CommentDto ToCommentDto(this Comment commentModel)
        {
            return new CommentDto
            {
                Id = commentModel.Id,
                Title = commentModel.Title,
                Content = commentModel.Content,
                CreatedOn = commentModel.CreatedOn,
                CreatedBy = commentModel.AppUser?.UserName, // Check for null
                StockId = commentModel.StockId
            };
        }

        public static Comment ToCommentFromCreate(this CreateCommentDto commentDto, int stockId, AppUser appUser)
        {
            return new Comment
            {
                Title = commentDto.Title,
                Content = commentDto.Content,
                StockId = stockId,
                AppUser = appUser // Assign AppUser property
            };
        }

        public static Comment ToCommentFromUpdate(this UpdateCommentRequestDto commentDto, int commentId, AppUser appUser)
        {
            return new Comment
            {
                Id = commentId,
                Title = commentDto.Title,
                Content = commentDto.Content,
                AppUser = appUser // Assign AppUser property
            };
        }

    }
}
