using System;
using System.Collections.Generic;
using System.Linq;

using capa_entidad;
using capa_dato;

namespace capa_negocio
{
    public class CN_Usuarios
    {
        
        CD_Usuarios oCD_Usuarios = new CD_Usuarios();

        
        public List<CE_usuarios> Listar()
        {
            try
            {
                
                return oCD_Usuarios.ListarUsuarios();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de usuarios: " + ex.Message);
            }
        }

        public void Insertar(CE_usuarios usuario)
        {
           

            
            if (string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                throw new ArgumentException("El nombre de usuario no puede estar vacío.");
            }
            if (string.IsNullOrWhiteSpace(usuario.Clave))
            {
                throw new ArgumentException("La contraseña es obligatoria.");
            }

            
            if (usuario.Clave.Length < 6)
            {
                throw new ArgumentException("La contraseña debe tener al menos 6 caracteres.");
            }

            

            try
            {
               

                oCD_Usuarios.InsertarUsuarios(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al insertar el usuario: " + ex.Message);
            }
        }

        
        public void Actualizar(CE_usuarios usuario)
        {
            
            if (usuario.IdUsuario <= 0)
            {
                throw new ArgumentException("Se requiere un ID de Usuario válido para actualizar.");
            }

            if (string.IsNullOrWhiteSpace(usuario.Nombre))
            {
                throw new ArgumentException("El nombre de usuario no puede estar vacío.");
            }
            

            try
            {
                
                oCD_Usuarios.ActualizarUsuarios(usuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el usuario: " + ex.Message);
            }
        }

        
        public void Eliminar(int idUsuario)
        {
            
            if (idUsuario <= 0)
            {
                throw new ArgumentException("Se requiere un ID de Usuario para eliminar.");
            }

            try
            {
                oCD_Usuarios.EliminarUsuarios(idUsuario);
            }
            catch (Exception ex)
            {
                throw new Exception("Error al eliminar el usuario: " + ex.Message);
            }
        }

        
    }
}