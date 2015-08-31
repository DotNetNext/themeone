using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SqlSugar;
using ThemeOne.Entities;
namespace ThemeOne.Infrastructure
{
    public class ListService : IDisposable
    {
        public SqlSugar.SqlSugarClient db = SugarDao.GetInstance();
        public Sqlable GetListSqlable()
        {
            Sqlable sable = db.Sqlable().Form<list>("g");//查询表的sqlable对象
            return sable;
        }

        public bool Save(list list)
        {
            var isAdd = list.id == 0;
            if (isAdd)
            {
                return db.Insert(list) != DBNull.Value;
            }
            else
            {
                return db.Update<list>(list, it => it.id == list.id);
            }

        }
        public bool Delete(int id)
        {
            return db.Delete<list>(id);
        }

        public void Dispose()
        {
            if (db != null)
            {
                db.Dispose();
            };
        }

     
    }
}
