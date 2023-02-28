using datamodel.models;
using datamodel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class InsuranceMasterController : ControllerBase
    {
        private imftenant_DbContext context;
       
        [HttpPost, Route("categories")]
        public IActionResult AddCategories(InsuranceCategory insuranceCategory)
        {
            bool isExists=false;
            if (insuranceCategory.id!=Guid.Empty)
            {
                isExists = isInsuranceCategoryExist(insuranceCategory.id);
            }
            var result = isExists ? UpdateInuranceCategory(insuranceCategory) : AddInuranceCategory(insuranceCategory);
            return Ok(result);
        }
        [HttpPost, Route("Plans")]
        public IActionResult AddPlans(List<InsurancePlan> insuranceplans)
        {
            var existingInsurancePlan = insuranceplans[0].InsuranceCategoryId != Guid.Empty ? GetInsurancePlans(insuranceplans[0].InsuranceCategoryId) : null;

            if (existingInsurancePlan!=null && existingInsurancePlan.Count>0)
            {
                using (context = new imftenant_DbContext(new DbContextOptions<imftenant_DbContext>()))
                {
                    context.RemoveRange(existingInsurancePlan);
                    context.SaveChanges();
                }
            }
            using (context = new imftenant_DbContext(new DbContextOptions<imftenant_DbContext>()))
            {
                context.AddRange(insuranceplans);
                context.SaveChanges();
            }
            return Ok(insuranceplans);
        }
        [HttpGet, Route("categories")]
        public IActionResult Categories([FromQuery]string orderBy, string direction)
        {
            try
            {
                using (context = new imftenant_DbContext(new DbContextOptions<imftenant_DbContext>()))
                {
                    var categories = context.InsuranceCategories.AsQueryable().OrderBy(orderBy +" "+ direction).ToList();
                    return Ok(categories);
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        [HttpGet, Route("plans")]
        public IActionResult Plans([FromQuery]Guid categoryId, string orderBy, string direction)
        {
            return Ok(GetInsurancePlans(categoryId, orderBy, direction));
        }

        [HttpDelete, Route("plans")]
        public IActionResult DeletePlans([FromQuery] Guid id)
        {
            bool isSuccess = false;
            using (context = new imftenant_DbContext(new DbContextOptions<imftenant_DbContext>()))
            {
                var plans = context.InsurancePlans.Where(x => x.id == id).FirstOrDefault();
                context.Remove<InsurancePlan>(plans);
                isSuccess= context.SaveChanges()>0?true:false;
            }
            return Ok(isSuccess);
        }

        [HttpDelete, Route("categories")]
        public IActionResult DeleteCategory([FromQuery] Guid id)
        {
            bool isSuccess = false;
            using (context = new imftenant_DbContext(new DbContextOptions<imftenant_DbContext>()))
            {
                var categories = context.InsuranceCategories.Where(x => x.id == id).FirstOrDefault();
                context.Remove<InsuranceCategory>(categories);
                isSuccess = context.SaveChanges() > 0 ? true : false;
            }
            return Ok(isSuccess);
        }

        [HttpPost, Route("Plans")]
        public IActionResult AddInsurancePolicy(InsuranceDetailsModel insuranceDetail)
        {
            //var existingInsurancePlan = insuranceplans[0].InsuranceCategoryId != Guid.Empty ? GetInsurancePlans(insuranceplans[0].InsuranceCategoryId) : null;

            //if (existingInsurancePlan != null && existingInsurancePlan.Count > 0)
            //{
            //    using (context = new cruse07_DbContext(new DbContextOptions<cruse07_DbContext>()))
            //    {
            //        context.RemoveRange(existingInsurancePlan);
            //        context.SaveChanges();
            //    }
            //}
            //using (context = new cruse07_DbContext(new DbContextOptions<cruse07_DbContext>()))
            //{
            //    context.AddRange(insuranceplans);
            //    context.SaveChanges();
            //}
            return Ok(insuranceDetail);
        }
        #region private methods

        private bool isInsuranceCategoryExist(Guid id) 
        {
            using (context = new imftenant_DbContext(new DbContextOptions<imftenant_DbContext>()))
            {
                var result = context.InsuranceCategories.Where(x => x.id==id).Any() ? true : false;
                return result;
            }
          
        }
        private InsuranceCategory AddInuranceCategory(InsuranceCategory insuranceCategory) 
        {
            using (context = new imftenant_DbContext(new DbContextOptions<imftenant_DbContext>()))
            {
                context.Add<InsuranceCategory>(insuranceCategory);
                context.SaveChanges();
                return insuranceCategory;
            }
                
        }
        private InsuranceCategory UpdateInuranceCategory(InsuranceCategory insuranceCategory)
        {
            using (context = new imftenant_DbContext(new DbContextOptions<imftenant_DbContext>()))
            {
                var _insuranceCategory = context.InsuranceCategories.Where(x => x.id == insuranceCategory.id).FirstOrDefault();
                _insuranceCategory.Name = insuranceCategory.Name;
                _insuranceCategory.IsActive = insuranceCategory.IsActive;
                context.InsuranceCategories.Update(_insuranceCategory);
                context.SaveChanges();
                return _insuranceCategory;
            }    
        }
        private List<InsurancePlan> GetInsurancePlans(Guid insuranceCategotyId, string orderBy="Name", string direction="ASC") 
        {
            try
            {
                using (context = new imftenant_DbContext(new DbContextOptions<imftenant_DbContext>()))
                {
                    var plans = context.InsurancePlans.Where(x => x.InsuranceCategoryId == insuranceCategotyId).AsQueryable().OrderBy(orderBy + " " + direction).ToList();
                    return plans;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion private methods
    }
}
