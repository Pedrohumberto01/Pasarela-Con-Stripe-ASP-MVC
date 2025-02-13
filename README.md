# Pasarela

Este proyecto es una implementación de una pasarela de pagos usando ASP.NET MVC y Stripe, diseñada para facilitar la integración de pagos en línea en aplicaciones web. permite que usuarios compren productos de manera segura utilizando el sistema de pagos de Stripe.

## Características
- Integración con Stripe: La aplicación usa la API de Stripe para crear sesiones de pago y procesar transacciones.
- Interfaz de usuario amigable: Presenta una lista de productos con imágenes, precios y un botón para realizar el pago.
- Redirección automática: Después de hacer clic en "Comprar", el usuario es redirigido a la página de pago de Stripe para completar la compra.
- Soporte a multiples productos, con posibilidad de conectarse a una base de datos

## Requisitos
- Visual Studio 2022 o superior
- .NET 8 SDK
- Cuenta de Stripe: Para obtener las claves necesarias para integrar Stripe.

### Instrucciones de instalación
- Clonar el repositorio:
```
git clone https://github.com/Pedrohumberto01/Pasarela-Con-Stripe-ASP-MVC.git
```

### Abrir en Visual Studio
- Abre Visual Studio 2022.
- En el menú, selecciona Archivo > Abrir > Proyecto/Solución.
- Navega hasta la carpeta donde clonaste el repositorio y selecciona el archivo .sln para abrir el proyecto.

### Instalar dependencias
```
dotnet restore
```

### Configurar Stripe

- Ve a Stripe y crea una cuenta si no tienes una.
- Obtén las claves públicas y secretas de Stripe desde tu dashboard.
- En el archivo appsettings.json, agrega las claves de Stripe:

```
"Stripe": {
  "PublishableKey": "tu_clave_publica_de_stripe",
  "SecretKey": "tu_clave_secreta_de_stripe"
}
```

### Ejecutar la aplicación
Una vez configurado todo, puedes ejecutar el proyecto presionando F5 o seleccionando Iniciar en Visual Studio.
