using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BAL.DTOs;
using BAL.Services.RolePermissionService;
using Domain;

namespace WebApp.Controllers.Api
{
    public class RolePermissionsController : ApiController
    {
        private readonly IRolePermissionService _rolePermissionService;

        public RolePermissionsController(IRolePermissionService rolePermissionService)
        {
            _rolePermissionService = rolePermissionService;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return Ok(_rolePermissionService.All());
        }

        public IHttpActionResult Get(int id)
        {
            var rolePermission = _rolePermissionService.GetById(id);
            if (null == rolePermission)
            {
                return NotFound();
            }
            return Ok(rolePermission);
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] RolePermissionDTO rolePermission)
        {
            var rolePermissionAdded = _rolePermissionService.Add(rolePermission);
            return CreatedAtRoute("DefaultApi", new { id = rolePermission.RolePermissionId }, rolePermissionAdded);
        }

        [HttpDelete]
        public IHttpActionResult DeleteEntity(int id)
        {
            var rolePermission = _rolePermissionService.GetById(id);
            if (null == rolePermission)
            {
                return NotFound();
            }
            rolePermission = _rolePermissionService.Delete(id);
            return Ok(rolePermission);
        }

        [HttpPut]
        public IHttpActionResult UpdateEntity([FromBody] RolePermissionDTO rolePermission)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _rolePermissionService.Update(rolePermission);
            return StatusCode(HttpStatusCode.NoContent);
        }

    }
}
