using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Pasarela.Models;
using Stripe.Checkout;

public class HomeController : Controller
{
    private readonly IConfiguration _configuration;

    public HomeController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    // cargar el index con datos de prueba
    public IActionResult Index()
    {
        var productos = new List<Productos>
        {
            new Productos
            {
                Nombre = "Camara Sony: Insignia α1 II para profesionales",
                Precio = 10 * 100,
                Img = "https://sony.scene7.com/is/image/sonyglobalsolutions/529_category?$goldenAreaImage$&fmt=png-alpha"
            },
            new Productos
            {
                Nombre = "Camara Canon: EOS 90D",
                Precio = 15 * 100,
                Img = "https://quecamarareflex.com/wp-content/uploads/2023/07/canon_R50-viewFO-objetivo.jpg"
            },
            new Productos
            {
                Nombre = "Cámara Digital de Bolsillo HD",
                Precio = 20 * 100,
                Img = "https://i5.walmartimages.com/asr/ab035376-4dbb-4eca-b477-a829ca0ffc4b.838eb3ab8c3342fbac6edeefa6657fe6.jpeg?odnHeight=612&odnWidth=612&odnBg=FFFFFF"
            }
        };

        // pasamos la clave a la vista
        var stripePublishableKey = _configuration["Stripe:PublishableKey"];
        ViewBag.StripePublishableKey = stripePublishableKey;

        // retornamos la vista y pasamos los productos creados
        return View(productos);
    }

    // crear la session de compra, "checkout session"
    [HttpPost]
    public IActionResult CreateCheckoutSession([FromBody] Productos producto)
    {
        // construye la url para los casos de ser susccess o cancel 
        var domain = $"{Request.Scheme}://{Request.Host}";

        // crea la session stripe
        var options = new SessionCreateOptions
        {
            // metodo de pago "tarjetas de crediito o debito del mundo"
            PaymentMethodTypes = new List<string> { "card" },
            // configuración del producto y precio
            LineItems = new List<SessionLineItemOptions>
            {
                new SessionLineItemOptions
                {
                    PriceData = new SessionLineItemPriceDataOptions
                    {
                        Currency = "usd", 
                        UnitAmount = producto.Precio, 
                        ProductData = new SessionLineItemPriceDataProductDataOptions
                        {
                            Name = producto.Nombre,
                            Images = new List<string> { producto.Img }
                        },
                    },
                    Quantity = 1,
                },
            },
            // el usuario realizara un pago completo
            Mode = "payment",

            // definir las url en caso de exito o error, en este caso ambos devuelven a la raiz del proyecto
            SuccessUrl = $"{domain}/",
            CancelUrl = $"{domain}/",
        };

        // crear la session con el sdk de stripe
        var service = new SessionService();
        var session = service.Create(options);

        // devolver la session en forma de json
        return Json(new { sessionId = session.Id });
    }

}

