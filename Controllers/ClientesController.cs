using ClienteApi.Data;
using ClienteApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClienteApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly ApiDbContext _context;

        public ClientesController(ApiDbContext context)
        {
            _context = context;
        }

        // === ENDPOINTS DE CLIENTE ===

        // GET: api/clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes()
        {
            return await _context.Clientes.ToListAsync();
        }

        // GET: api/clientes/5
        [HttpGet("{id}", Name = "GetCliente")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/clientes/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest("O ID na URL não corresponde ao ID no corpo da requisição.");
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/clientes
        [HttpPost]
        public async Task<ActionResult<Cliente>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCliente", new { id = cliente.Id }, cliente);
        }

        // DELETE: api/clientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }

        // === ENDPOINTS DE PEDIDOS DO CLIENTE ===

        // GET: api/clientes/5/pedidos
        [HttpGet("{clienteId}/pedidos")]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidosDoCliente(int clienteId)
        {
            var cliente = await _context.Clientes.FindAsync(clienteId);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            // Filtra os pedidos pelo ClienteId
            var pedidos = await _context.Pedidos
                                        .Where(p => p.ClienteId == clienteId)
                                        .ToListAsync();

            return Ok(pedidos);
        }

        // POST: api/clientes/5/pedidos
        [HttpPost("{clienteId}/pedidos")]
        public async Task<ActionResult<Pedido>> PostPedidoParaCliente(int clienteId, Pedido pedido)
        {
            var cliente = await _context.Clientes.FindAsync(clienteId);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }

            // Associa o pedido ao cliente
            pedido.ClienteId = clienteId;
            // Define a data do pedido para o momento atual
            pedido.DataPedido = DateTime.UtcNow;

            _context.Pedidos.Add(pedido);
            await _context.SaveChangesAsync();

            // Retorna o pedido criado
            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, pedido);
        }
    }
}