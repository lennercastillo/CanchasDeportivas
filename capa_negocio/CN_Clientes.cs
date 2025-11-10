using System;
using System.Collections.Generic;
using System.Linq;
// Incluye los namespaces de tus otras capas
using capa_entidad;
using capa_dato;

namespace capa_negocio
{
    public class CN_Clientes
    {
        // Instancia de la Capa de Datos para poder ejecutar las operaciones SQL
        private CD_Clientes_cs oCD_Clientes = new CD_Clientes_cs();

        // 1. Listar Clientes
        // Solo llama a la Capa de Datos, ya que el listado generalmente no requiere lógica de negocio compleja.
        public List<CE_Clientes> Listar()
        {
            try
            {
                // Llama al método de la Capa de Datos
                return oCD_Clientes.Listar();
            }
            catch (Exception ex)
            {
                // Manejo de errores: en un proyecto real, se registraría el error.
                throw new Exception("Error en la Capa de Negocio al listar clientes: " + ex.Message);
            }
        }

        // 2. Insertar Nuevo Cliente
        public void Insertar(CE_Clientes cliente)
        {
            // ** LÓGICA DE NEGOCIO Y VALIDACIONES **
            // ------------------------------------------------------------------
            if (string.IsNullOrWhiteSpace(cliente.Nombre))
            {
                throw new ArgumentException("El nombre del cliente no puede estar vacío.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Correo) || !cliente.Correo.Contains("@"))
            {
                throw new ArgumentException("Debe proporcionar un correo electrónico válido.");
            }

            // Aquí se podría añadir validación para:
            // - Formato de teléfono (usando RegEx).
            // - Verificación de que el correo no exista ya en la base de datos (con una consulta adicional).
            // ------------------------------------------------------------------

            try
            {
                oCD_Clientes.Insertar(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la Capa de Negocio al insertar cliente: " + ex.Message);
            }
        }

        // 3. Actualizar Cliente
        public void Actualizar(CE_Clientes cliente)
        {
            // ** LÓGICA DE NEGOCIO Y VALIDACIONES **
            // ------------------------------------------------------------------
            if (cliente.IdCliente <= 0)
            {
                throw new ArgumentException("Se requiere un Id de Cliente válido para actualizar.");
            }

            if (string.IsNullOrWhiteSpace(cliente.Telefono))
            {
                throw new ArgumentException("El campo Teléfono no puede estar vacío.");
            }
            // ------------------------------------------------------------------

            try
            {
                oCD_Clientes.Actualizar(cliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la Capa de Negocio al actualizar cliente: " + ex.Message);
            }
        }

        // 4. Eliminar Cliente
        public void Eliminar(int IdCliente)
        {
            // ** LÓGICA DE NEGOCIO Y VALIDACIONES **
            // ------------------------------------------------------------------
            if (IdCliente <= 0)
            {
                throw new ArgumentException("Se requiere un Id de Cliente para eliminar.");
            }

            // Aquí se podría añadir una validación crítica:
            // - Verificar si el cliente tiene reservas o transacciones pendientes. 
            //   Si las tiene, se podría lanzar una excepción para evitar la eliminación.
            // ------------------------------------------------------------------

            try
            {
                oCD_Clientes.Eliminar(IdCliente);
            }
            catch (Exception ex)
            {
                throw new Exception("Error en la Capa de Negocio al eliminar cliente: " + ex.Message);
            }
        }
    }
}