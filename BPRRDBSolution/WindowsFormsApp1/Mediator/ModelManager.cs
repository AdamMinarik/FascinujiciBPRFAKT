using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Mediator
{
    class ModelManager : RDBModel
    {
        private Storage storage;


        public ModelManager()
        {
            storage = new Storage();
        }


        public void addItem(EProjectItem item, bool approval)
        {
            throw new NotImplementedException();
        }

        public EProjectItemList getClosedItems(int projectID, string month, string type)
        {
            throw new NotImplementedException();
        }

        public ExecutionUser getExecutionUser(string userName)
        {
              return storage.getExecutionUser(userName);
        }

        public EProjectItemList getFilterItems(int projectID, string month, string field, string fieldValue)
        {
            throw new NotImplementedException();
        }

        public EProjectItemList getItems(int projectID, string month, string type)
        {
            throw new NotImplementedException();
        }

        public Project getProject(int projectID)
        {
            throw new NotImplementedException();
        }

        public EProjectItemList getRemovedItems(int projectID, string month, string type)
        {
            throw new NotImplementedException();
        }

        public EProjectItemList getWatchlistItems(int projectID, string month, string type)
        {
            throw new NotImplementedException();
        }

        public void updateChangedItem(EProjectItem item)
        {
            throw new NotImplementedException();
        }

        public void updateItem(EProjectItem item, bool projectOwner)
        {
            throw new NotImplementedException();
        }

        public void updateNewItem(EProjectItem item)
        {
            throw new NotImplementedException();
        }

        public void updateProject(Project project)
        {
            throw new NotImplementedException();
        }
    }
}
