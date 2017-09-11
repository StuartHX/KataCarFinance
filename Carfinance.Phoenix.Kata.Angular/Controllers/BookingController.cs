using Carfinance.Phoenix.Kata.Angular.Models;
using Carfinance.Phoenix.Kata.Angular.Services;
using Carfinance.Phoenix.Kata.Angular.Services.Interfaces;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Web.Http;
using System.Net;
using System.Net.Http;
using System;
using System.Linq;

namespace Carfinance.Phoenix.Kata.Angular.Controllers
{
    /// <summary>
    /// Your Name:
    /// Date: 
    /// Random fact about you: 
    /// </summary>
    /// <seealso cref="System.Web.Http.ApiController" />
    [RoutePrefix("booking")]
    public class BookingController : ApiController
    {
        kataEntities db = null;

        public BookingController()
        {
            db = new kataEntities();
        }

        /// <summary>
        /// Gets all bookings
        /// </summary>
        [HttpGet]
        [Route("")]
        public IEnumerable<Booking> Get()
        {
            var bb = db.Bookings;
            return db.Bookings.AsEnumerable();
        }

        /// <summary>
        /// Gets a single booking
        /// </summary>
        public Booking Get(int id)
        {
            Booking booking = db.Bookings.Find(id);
            if (booking == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return booking;
        }

        /// <summary>
        /// Add a new booking
        /// </summary>
        /// <param name="booking"></param>
        [System.Web.Http.HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody]Booking booking)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
            HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, booking);
            return response;
        }

        /// <summary>
        /// Update an existing booking
        /// </summary>
        /// <param name="BookingId"></param>
        /// <param name="booking"></param>
        [System.Web.Http.HttpPut]
        [Route("")]
        public HttpResponseMessage Put(Booking booking)
        {            
            db.Entry(booking).State = EntityState.Modified;
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}