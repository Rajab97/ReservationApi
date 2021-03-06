﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MeetingRoomApi.DTOs.MemberDtos;
using MeetingRoomApi.Models;
using MeetingRoomApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace MeetingRoomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMemberService _memberService;

        public AuthController(IAuthService authService,IConfiguration configuration ,IMapper mapper, IHttpContextAccessor httpContextAccessor,IMemberService memberService)
        {
            _authService = authService;
            _configuration = configuration;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
            _memberService = memberService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(ReqisterMemberDto reqisterMemberDto)
        {
            try
            {
                if (await _authService.MemberExist(reqisterMemberDto.UserName))
                    return BadRequest("Username already exist");


                await _authService.Reqister(reqisterMemberDto, Helpers.Roles.User);
                await _authService.CommitAsync();
            }
            catch (Exception)
            {
                return StatusCode(400);
            }
            return StatusCode(201);
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginMemberDto loginMemberDto)
        {
            Member member = await _authService.Login(loginMemberDto);
     
            if (member == null)
                return Unauthorized("İstifadəçi adında və ya kodda səflik var.");
            string role = await _authService.Role(member);
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier , member.Id.ToString()),
                new Claim(ClaimTypes.Name, member.Name +" " + member.Surname),
                new Claim(ClaimTypes.GivenName, member.UserName),
                new Claim(ClaimTypes.Role, role)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSettings:Token").Value));

            var publicKey = new SigningCredentials(key,SecurityAlgorithms.HmacSha512Signature);

            var tokenDescription = new SecurityTokenDescriptor() {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.Now.AddDays(365),
                    SigningCredentials = publicKey
            };

            var JWThandler = new JwtSecurityTokenHandler();
            var token = JWThandler.CreateToken(tokenDescription);

            return Ok(new {  Token = JWThandler.WriteToken(token) });
        }
      
    /*    [HttpPost("changeColor")]
        public async Task<ActionResult> ChangeColor(ChangeColorDto dto)
        {
            await _authService.ChangeColor(dto.Color);
            return Ok(new { message = "Changed succesfully" });
        }*/
     
    }
}