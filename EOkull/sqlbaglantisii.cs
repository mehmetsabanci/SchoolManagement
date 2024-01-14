using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOkull
{
    internal class sqlbaglantisii
    {
        public SqlConnection baglanti()
        {
            SqlConnection baglan = new SqlConnection("Data Source = Mehmet\\SQLEXPRESS; Initial Catalog = EOkull; Integrated Security = True; Encrypt = False");
            baglan.Open();
            return baglan;
        }
    }
}
