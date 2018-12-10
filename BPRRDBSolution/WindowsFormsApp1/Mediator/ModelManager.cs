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


        public void addItem(EProjectItem item, bool approval,String Type, int ProjectID, String userName)
        {
            storage.addItem(item, approval, Type, ProjectID, userName);
        }

        public EProjectItemList getClosedItems(int projectID, string month, string type)
        {
            throw new NotImplementedException();
        }

        public ExecutionUser getExecutionUser(string userName)
        {
              return storage.getExecutionUser(userName);
        }

        public EProjectItemList getFilterItems(int projectID, DateTime month, int field, int fieldValue)
        {
            return storage.getFilterItems(projectID, month, field, fieldValue);
        }

        public EProjectItemList getItems(int projectID, DateTime month, string type)
        {
            return storage.getItems(projectID, month, type);
        }

        public ExecutionProject getExecutionProject(int projectID)
        {
            return storage.getExecutionProject(projectID);
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

        public void updateItem(EProjectItem item, bool projectOwner, String type)
        {
            storage.updateItem(item, projectOwner, type);
        }

        public void updateNewItem(EProjectItem item)
        {
            throw new NotImplementedException();
        }

        public void updateProject(ExecutionProject project)
        {
            storage.updateProject(project);
        }

        public void approveNewItem(int projectID, int newItemID)
        {
            storage.approveNewItem(projectID, newItemID);
        }

        public void declineNewItem(int projectID, int newItemID)
        {
            storage.declineNewItem(projectID, newItemID);
        }

        public void approveChangedItem(int projectID, int changedItemID, int UpdatedColID, string newValueString, int newColumnID, string updatedColumntxt, int idOfChange)
        {
            storage.approveChangedItem(projectID, changedItemID, UpdatedColID, newValueString, newColumnID, updatedColumntxt, idOfChange);
        }

        public void declineChangedItem(int projectID, int changedItemID, int UpdatedColID, string newValueString, int newColumnID, string updatedColumntxt, int idOfChange)
        {
            storage.declineChangedItem(projectID, changedItemID, UpdatedColID, newValueString, newColumnID, updatedColumntxt, idOfChange);
        }
    }
}
