using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WindowsFormsApp1.Model;

namespace WindowsFormsApp1.Mediator
{
    interface RDBModel
    {
        //GETS
        ExecutionProject getExecutionProject(int projectID);
        EProjectItemList getItems(int projectID, DateTime month, String type);
        EProjectItemList getFilterItems(int projectID, DateTime month, int field, int fieldValue);
        EProjectItemList getRemovedItems(int projectID, String month, String type);
        EProjectItemList getWatchlistItems(int projectID, String month, String type);
        EProjectItemList getClosedItems(int projectID, String month, String type);
        ExecutionUser getExecutionUser(string userName);
        
        //INSERTS
        void addItem(EProjectItem item, bool approval, String Type, int ProjectID, String userName);
        //UPDATES
        void updateProject(ExecutionProject project);
        void updateItem(EProjectItem item, bool projectOwner, String type);
        void updateNewItem(EProjectItem item);
        void updateChangedItem(EProjectItem item);
        void approveNewItem(int projectID, int newItemID);
        void declineNewItem(int projectID, int newItemID);
        void approveChangedItem(int projectID, int changedItemID, int UpdatedColID, string newValueString, int newColumnID, string updatedColumntxt, int idOfChange);
        void declineChangedItem(int projectID, int changedItemID, int UpdatedColID, string newValueString, int newColumnID, string updatedColumntxt, int idOfChange);
    }
}
