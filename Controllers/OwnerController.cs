using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using SDA;
using CloudApiWebApp.DTOs;
using CloudApiWebApp.Helpers;
using System.Globalization;

namespace CloudApiWebApp.Controllers
{
    [Route("bus/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        TICKET2019Entities _context;
        public OwnerController(TICKET2019Entities context)
        {
            _context = context;
            _context.Configuration.ProxyCreationEnabled = false;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetServiceProviders()
        {
            var providersData = from org in _context.Organizations
                                  join attachment in _context.Attachments on org.code equals attachment.reference
                                  join address in _context.Addresses on org.code equals address.reference
                                  where org.isActive && attachment.type == TICKET2020Constants.ATT_TYPE_LOGO && address.type == TICKET2020Constants.ADD_TYPE_PHONE
                                  select new { tin = org.remark, org.tradeName, org.brandName, address = address.value, logoURL = attachment.url, connectionString = org.remark };

            var providers = await providersData.ToListAsync();

            return Ok(providers);
        }

        [HttpPost("GetTrips")]
        public async Task<IActionResult> GetTrips(GetByDateRange range)
        {
            try
            {
                if (range == null)
                {
                    return NotFound();
                }
                DateTime startDate, endDate;

                startDate = string.IsNullOrWhiteSpace(range.fromDate) ? DateTime.Now.Date : DateTime.ParseExact(range.fromDate, TICKET2020Constants.dateFormat, CultureInfo.InvariantCulture);
                endDate = string.IsNullOrWhiteSpace(range.toDate) ? DateTime.Now.Date : DateTime.ParseExact(range.toDate, TICKET2020Constants.dateFormat, CultureInfo.InvariantCulture);

                if (startDate > endDate)
                {
                    return NotFound();
                }

                if (!string.IsNullOrWhiteSpace(range.id))
                {
                    using (TICKET2019Entities _orgContext = new TICKET2019Entities(await helper.buildConnectionString(range.id)))
                    {
                        var tripDetails = from tp in _orgContext.vw_TripInfo
                                          where tp.tripIsActive && tp.tripDate >= startDate && tp.tripDate <= endDate
                                          select new {id = range.id, tp.tripCode, tp.routeDesc, tp.tripDate, tp.busDesc, tp.tripDiscount, tp.tripUnitAmount, tp.timeLength };
                        var tripDetail = await tripDetails.ToArrayAsync();
                        if (tripDetail != null)
                        {
                            return Ok(tripDetail);
                        }
                        else
                        {
                            return NoContent();
                        }
                    }
                }
                else
                {
                    var tripsTask = Task.Run(() =>  _context.spSearchTripsFromActiveProviders(range.source, range.destination, null, startDate.ToString("yyyy-MM-dd"), endDate.ToString("yyyy-MM-dd")).ToList());
                    var availableTrips = await tripsTask;

                    if(availableTrips != null)
                    {
                        return Ok(availableTrips);
                    }
                    else
                    {
                        return NoContent();
                    }
                }
            }
            catch (Exception)
            {
                return NotFound();
            }
        }

        [HttpPost("getTripDetail")]
        public async Task<IActionResult> GetTripDetail(GetByCode code)
        {
            if(code == null || string.IsNullOrWhiteSpace(code.id) || string.IsNullOrWhiteSpace(code.itemCode))
            {
                return NotFound();
            }

            if (await _context.Organizations.AnyAsync(u => u.remark == code.id))
            {
                using (TICKET2019Entities _orgContext = new TICKET2019Entities(await helper.buildConnectionString(code.id)))
                {
                    var tripDetails = from tp in _orgContext.vw_TripInfo
                                      where tp.tripIsActive && tp.tripCode == code.itemCode
                                      select new { tp.tripCode, tp.routeDesc, tp.tripDate, tp.busDesc, tp.tripDiscount, tp.tripUnitAmount, tp.timeLength };
                    var tripDetail = await tripDetails.FirstOrDefaultAsync();
                    if(tripDetail != null)
                    {
                        return Ok(tripDetail);
                    }
                    else
                    {
                        return NoContent();
                    }
                }
            }
            return NotFound();
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
