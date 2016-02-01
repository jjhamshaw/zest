using System;
using SQLite;

namespace ZestNew
{
    public class RecordDao
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}

