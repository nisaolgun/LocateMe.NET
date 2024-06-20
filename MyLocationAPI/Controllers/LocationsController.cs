using Microsoft.AspNetCore.Mvc;
using MyLocationAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyLocationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private static List<Location> _locations = new List<Location>();

        [HttpGet]
        public IActionResult GetLocations()
        {
            return Ok(_locations);
        }

        [HttpGet("{id}")]
        public IActionResult GetLocationById(int id)
        {
            var location = _locations.FirstOrDefault(l => l.Id == id);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }

        [HttpPost]
        public IActionResult AddLocation([FromBody] Location location)
        {
            location.Id = _locations.Count + 1;
            _locations.Add(location);
            return CreatedAtAction(nameof(GetLocationById), new { id = location.Id }, location);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateLocation(int id, [FromBody] Location updatedLocation)
        {
            var location = _locations.FirstOrDefault(l => l.Id == id);
            if (location == null)
            {
                return NotFound();
            }

            location.Name = updatedLocation.Name;
            location.Latitude = updatedLocation.Latitude;
            location.Longitude = updatedLocation.Longitude;

            return Ok(location);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteLocation(int id)
        {
            var location = _locations.FirstOrDefault(l => l.Id == id);
            if (location == null)
            {
                return NotFound();
            }

            _locations.Remove(location);
            return NoContent();
        }

        [HttpGet("nearby")]
        public IActionResult GetNearbyLocations(double latitude, double longitude)
        {
            
            var nearbyLocations = new[]
            {
                new { Name = "Example Place 1", Latitude = latitude + 0.01, Longitude = longitude + 0.01 },
                new { Name = "Example Place 2", Latitude = latitude - 0.01, Longitude = longitude - 0.01 }
            };

            return Ok(nearbyLocations);
        }
    }
}
