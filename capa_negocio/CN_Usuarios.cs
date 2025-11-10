using System;
using System.Collections.Generic;
using System.Linq;
// Asegúrate de incluir los namespaces correctos
using capa_entidad;
using capa_dato;

namespace capa_negocio
{
    public class CN_Usuarios
    {
        // Instancia de la Capa de Datos para la comunicación con la DB
        private CD_Usuarios oCD_Usuarios = new CD_Usuarios();

        // 1. Listar Usuarios
        public List<CE_usuarios> Listar()
        {
            try
            {
                // Simple pasarela: la capa de negocio llama a la capa de datos
                return oCD_Usuarios.ListarUsuarios();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de usuarios: " + ex.Message);
            }
        }

        // 2. Insertar Nuevo Usuario
        public void Insertar(CE_usuarios usuario)
        {
            // ** LÓGICA DE NEGOCIO Y VALIDACIONES **
            // ------------------------------------------------------------------

            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                throw new ArgumentException("El nombre de usuario no puede estar vacío.");
            }
            if (string.IsNullOrWhiteSpace(usuario.Clave))
            {
                throw new ArgumentException("La contraseña es obligatoria.");
            }

            // Regla de Negocio: Longitud y complejidad de la contraseña
            if (usuario.Clave.Length < 6)
            {
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.");
            }

            // Regla de Negocio: Verificar si el nombre de usuario ya existe (Esto requiere un método de búsqueda en la CD)
            // if (oCD_Usuarios.ExisteUsuario(usuario.Nombre)) 
            // { 
            //     throw new ArgumentException("El nombre de usuario ya está registrado.");
            // }
            // ------------------------------------------------------------------

            try
            {
                // Nota de Seguridad: En una aplicación real, aquí se debería hashear la contraseña
                // (ej. usando BCrypt o SHA-256) antes de enviarla a la capa de datos.

                oCD_Usuarios.InsertarUsuarios(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el usuario: " + ex.Message);
            }
        }

        // 3. Actualizar Usuario
        public void Actualizar(CE_usuarios usuario)
        {
            // ** LÓGICA DE NEGOCIO Y VALIDACIONES **
            // ------------------------------------------------------------------
            if (usuario.IdUsuario <= 0)
            {
                throw new ArgumentException("Se requiere un ID de Usuario válido para actualizar.");
            }

            // Regla de Negocio: Se podría validar que la clave no se envíe vacía
            // O si solo se cambia el estado, que el resto de campos coincida con los datos existentes.
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                throw new ArgumentException("El nombre de usuario no puede estar vacío.");
            }
            // ------------------------------------------------------------------

            try
            {
                // Nota de Seguridad: Si se actualiza la clave, se debe hashear de nuevo.
                oCD_Usuarios.ActualizarUsuarios(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el usuario: " + ex.Message);
            }
        }

        // 4. Eliminar Usuario
        public void Eliminar(int idUsuario)
        {
            // ** LÓGICA DE NEGOCIO Y VALIDACIONES **
            // ------------------------------------------------------------------
            if (idUsuario <= 0)
            {
                throw new ArgumentException("Se requiere un ID de Usuario para eliminar.");
            }

            // Regla de Negocio Crítica: No permitir eliminar al último administrador o al usuario logueado.
            // if (EsUltimoAdmin(idUsuario)) { throw new Exception("No puedes eliminar el único usuario administrador."); }
            // ------------------------------------------------------------------

            try
            {
                oCD_Usuarios.EliminarUsuarios(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario: " + ex.Message);
            }
        }

        // ** NOTA ADICIONAL: Implementación de Login (Autenticación) **
        /* public CE_usuarios Autenticar(string nombreUsuario, string clave)
        {
            // 1. Validaciones básicas (no vacíos)
            // 2. Llamar a CD_Usuarios.BuscarPorNombre(nombreUsuario)
            // 3. Verificar si se encontró el usuario.
            // 4. Comparar la 'clave' proporcionada con la 'clave hasheada' almacenada en la DB.
            // 5. Devolver el objeto CE_usuarios o lanzar una excepción de credenciales inválidas.
            // return usuarioEncontrado;
        }
        */
    }
}