using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Northwind.Data.Entity
{
    public class Category
    {

        int _categoryID;
        string _categoryName;
        string _description;

        [Key]
        public int CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }

        public string CategoryName
        {
            get { return _categoryName; }
            set { _categoryName = value; }
        }

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
    }
}
