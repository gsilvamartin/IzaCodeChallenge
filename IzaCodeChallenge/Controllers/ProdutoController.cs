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
    public class ProdutoController : Controller
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService clienteService)
        {
            this._produtoService = clienteService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get()
        {
            try
            {
                var produtos = _produtoService.GetProdutos();

                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Produtos recuperados com sucesso",
                    Data = produtos
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
                var produto = _produtoService.GetProduto(id);

                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Produto recuperado com sucesso",
                    Data = produto
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
        public IActionResult Post([FromBody] Produto produto)
        {
            try
            {
                var idProduto = _produtoService.InsertProduto(produto);

                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Produto cadastrado com sucesso",
                    Data = idProduto
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
        public IActionResult Put([FromBody] Produto produto)
        {
            try
            {
                _produtoService.UpdateProduto(produto);

                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Produto atualizado com sucesso"
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
                _produtoService.DeleteProduto(id);

                return Ok(new APIResponse
                {
                    Success = true,
                    Message = "Produto deletado com sucesso"
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

