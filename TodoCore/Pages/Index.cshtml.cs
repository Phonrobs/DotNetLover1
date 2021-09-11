using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TodoCore.Models;
using TodoCore.Data;
using System;
using Microsoft.AspNetCore.Mvc;

namespace TodoCore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public TaskItem[] TaskItems;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            using (var da = new DataAccess())
            {
                TaskItems = da.GetTaskItems();
            }
        }

        public void OnPost(TaskItem data)
        {
            using (var da = new DataAccess())
            {
                da.CreateTaskItem(new TaskItem
                {
                    Subject = data.Subject,
                    IsComplete = data.IsComplete
                });
            }

            OnGet();
        }

        public void OnPostDelete(long id)
        {
            using (var da = new DataAccess())
            {
                da.DeleteTaskItem(id);
            }

            OnGet();
        }
    }
}
