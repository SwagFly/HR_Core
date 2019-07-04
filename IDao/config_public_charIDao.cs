using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;
namespace IDao
{
    /// <summary>
    /// 公共字段设置IDao
    /// </summary>
    public interface config_public_charIDao
    {
        //查询
        List<config_public_char> config_public_charSelect();
        //新增
        int config_public_charInsert(config_public_char pc);
        //删除
        int config_public_charDel(config_public_char pc,object keyValue);
    }
}
