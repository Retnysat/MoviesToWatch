using MoviesToWatch.App.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoviesToWatch.Domain.Entity;

namespace MoviesToWatch.App.Concrete
{
    public class MenuActionService : BaseService<MenuAction>
    {
        //private List<MenuAction> menuActions;

        public MenuActionService ()
        {
            Initialize();
        }

        public List<MenuAction> GetMenuActionsByMenuName(string menuName)
        {
            List<MenuAction> result = new List<MenuAction>();
            foreach (var menuAction in Items)
            {
                if (menuAction.MenuName == menuName)
                {
                    result.Add(menuAction);
                }
                              

            }
            return result;
        }

        private void Initialize()
        {
            AddItem(new MenuAction(1, "Add new movie", "Main"));
            AddItem(new MenuAction(2, "Delete movie from the list", "Main"));
            AddItem(new MenuAction(3, "Mark movie as watched", "Main"));
            AddItem(new MenuAction(4, "Find movie for evening", "Main"));
            AddItem(new MenuAction(5, "Exit", "Main"));
            AddItem(new MenuAction(1, "Action", "MovieType"));
            AddItem(new MenuAction(2, "Comedy", "MovieType"));
            AddItem(new MenuAction(3, "Serious", "MovieType"));
            AddItem(new MenuAction(4, "Thriller", "MovieType"));
            AddItem(new MenuAction(5, "Fantasy", "MovieType"));
            AddItem(new MenuAction(6, "None", "MovieType"));
            
        }
    }
}
