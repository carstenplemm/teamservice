using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using StatlerWaldorfCorp.TeamService.Models;
using System.Threading.Tasks;
using StatlerWaldorfCorp.TeamService.Persistence;

namespace StatlerWaldorfCorp.TeamService
{
	// comment
	public class TeamsController : Controller
	{
		ITeamRepository repository;

		public TeamsController(ITeamRepository repo) 
		{
			repository = repo;
		}

		[HttpGet]
        	public virtual IActionResult GetAllTeams()
		{
			return this.Ok(repository.GetTeams());
		}
		
		[HttpGet]
		public virtual void CreateTeam(Team team)
		{
			repository.Add(team);			
		}

		[HttpGet("{id}")]
        	public virtual IActionResult GetTeam(Guid id)
		{
			Team team = repository.Get(id);		

			if (team != null) 
			{				
				return this.Ok(team);
			} else {
				return this.NotFound();
			}			
		}

		[HttpPut("{id}")]
		public virtual IActionResult UpdateTeam(Team team, Guid id) 
		{
			team.ID = id;
			
			//repository.Update(team);			
			if(repository.Update(team) == null) {
				return this.NotFound();
			} else {
				return this.Ok(team);
			}
		}

		[HttpDelete("{id}")]
        	public virtual IActionResult DeleteTeam(Guid id)
		{
			Team team = repository.Delete(id);

			if (team == null) {
				return this.NotFound();
			} else {				
				return this.Ok(team.ID);
			}
		}
	}
}
