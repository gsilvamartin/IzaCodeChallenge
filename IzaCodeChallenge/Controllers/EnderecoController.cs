using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IzaCodeChallenge.Model;
using IzaCodeChallenge.Model.Database;
using IzaCodeChallenge.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IzaCodeChallenge.Controllers
{
    [Route("api/[controller]")]
    public class EnderecoController : Controller
    {
        private readonly IEnderecoService _enderecoService;

        public EnderecoController(IEnderecoService enderecoService)
        {
            this._enderecoService = enderecoService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                var enderecos = _enderecoService.GetEnderecos();

                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Endereços recuperados com sucesso",
                    Data = enderecos
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpGet("{id}")]
        [Authorize]
        public IActionResult Get(int id)
        {
            try
            {
                var endereco = _enderecoService.GetEndereco(id);

                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Endereço recuperado com sucesso",
                    Data = endereco
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Endereco endereco)
        {
            try
            {
                var idEndereco = _enderecoService.InsertEndereco(endereco);

                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Endereço cadastrado com sucesso",
                    Data = idEndereco
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult Put([FromBody] Endereco endereco)
        {
            try
            {
                _enderecoService.UpdateEndereco(endereco);

                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Endereço atualizado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }

        [HttpDelete("{id}")]
        [Authorize]
        public IActionResult Delete(int id)
        {
            try
            {
                _enderecoService.DeleteEndereco(id);

                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Endereços deletado com sucesso"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(new APIResponse
                {
                    Success = false,
                    Message = ex.Message
                });
            }
        }
    }
}

