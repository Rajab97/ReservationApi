using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using MeetingRoomApi.DTOs.MemberDtos;
using MeetingRoomApi.Models;
using MeetingRoomApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MeetingRoomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MemberController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAuthService _authService;
        private readonly IMemberService _memberService;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContext;

        public MemberController(IHttpContextAccessor httpContextAccessor , IAuthService authService, IMemberService memberService, IMapper mapper, IHttpContextAccessor httpContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _authService = authService;
            _memberService = memberService;
            _mapper = mapper;
            _httpContext = httpContext;
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult<MemberDetailsDto>> GetUser(short Id)
        {
            short userId = Convert.ToInt16(_httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            if (Id != userId)
                return Unauthorized("Bashqa istifadəçi məlumatlarını görə bilməzsən.");
            Member user = await _memberService.GetMember(userId);
            if (user == null)
                return Unauthorized("Icazən yoxdur.");

            MemberDetailsDto response = _mapper.Map<MemberDetailsDto>(user);
            return Ok(response);

        }
        [HttpPut("update")]
        public async Task<MemberDetailsDto> UpdateMemberDetails(MemberDetailsDto dto)
        {
            
            if (dto == null)
                throw new NullReferenceException("You must send member details.");
            if (!ModelState.IsValid)
                throw new ArgumentException("State isn't valid");
            short userId = Convert.ToInt16(_httpContext.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value);
            Member member = await _memberService.GetMember(userId);
            if (member == null)
                throw new UnauthorizedAccessException("User not found");

            Member sendedMember = _mapper.Map<Member>(dto);
            var updatedMember = await _memberService.UpdateMember(userId,sendedMember);
            var response = _mapper.Map<MemberDetailsDto>(updatedMember);
            return response;
        }
        [HttpPost("changePassword")]
        public async Task<ActionResult> ChangePassword(ChangePasswordDto changePasswordDto)
        {
            await _memberService.ChangePassword(changePasswordDto.LastPassword, changePasswordDto.NewPassword);
            return Ok(new { message = "Changed succesfully" });
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(ReqisterMemberDto reqisterMemberDto)
        {
            try
            {
                if (await _authService.MemberExist(reqisterMemberDto.UserName))
                    return BadRequest("Istifadeci adı artiq mövcuddur.");


                await _authService.Reqister(reqisterMemberDto, Helpers.Roles.User);
                await _authService.CommitAsync();
            }
            catch (Exception)
            {
                return StatusCode(400);
            }
            return StatusCode(201);
        }
    }
}