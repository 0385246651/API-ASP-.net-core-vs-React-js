using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        public DepartmentController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            string query = @"
                        select DepartmentId,DepartmentName from 
                        Department
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ConnectionString");
            MySqlDataReader myReader;
            // using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            using (MySqlConnection mycon = new MySqlConnection("server=127.0.0.1;port=3306;database=mytestdb;uid=root;password=Haidv1234*;"))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult(table);
        }


        [HttpPost]
        public JsonResult Post(Department dep)
        {
            string query = @"
                        insert into Department (DepartmentName) values
                                                    (@DepartmentName);
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ConnectionString");
            MySqlDataReader myReader;
            //using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            using (MySqlConnection mycon = new MySqlConnection("server=127.0.0.1;port=3306;database=mytestdb;uid=root;password=Haidv1234*;"))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentName", dep.DepartmentName);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }


        [HttpPut]
        public JsonResult Put(Department dep)
        {
            string query = @"
                        update Department set 
                        DepartmentName =@DepartmentName
                        where DepartmentId=@DepartmentId;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ConnectionString");
            MySqlDataReader myReader;
            //using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            using (MySqlConnection mycon = new MySqlConnection("server=127.0.0.1;port=3306;database=mytestdb;uid=root;password=Haidv1234*;"))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentId", dep.DepartmentId);
                    myCommand.Parameters.AddWithValue("@DepartmentName", dep.DepartmentName);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }



        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                        delete from .Department 
                        where DepartmentId=@DepartmentId;
                        
            ";

            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("ConnectionString");
            MySqlDataReader myReader;
            //using (MySqlConnection mycon = new MySqlConnection(sqlDataSource))
            using (MySqlConnection mycon = new MySqlConnection("server=127.0.0.1;port=3306;database=mytestdb;uid=root;password=Haidv1234*;"))
            {
                mycon.Open();
                using (MySqlCommand myCommand = new MySqlCommand(query, mycon))
                {
                    myCommand.Parameters.AddWithValue("@DepartmentId", id);

                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader);

                    myReader.Close();
                    mycon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }

    }
}