using System;
using System.Collections.Generic;
using System.Text;
using Prism.Mvvm;
using SQLite;

namespace TP2.Core.Repositories.Entities
{
    public class Entity : BindableBase
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
    }
}
