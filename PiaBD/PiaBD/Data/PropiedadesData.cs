using PiaBD.Models;
using System.Data;
using System.Data.SqlClient;

namespace PiaBD.Data
{
    public class PropiedadesData
    {
        private readonly string conexion;

        public PropiedadesData(IConfiguration configuration) 
        {
            conexion = configuration.GetConnectionString("PiaDBCon")!;
        }

        public async Task<List<Propiedad>> Lista()
        {
            List<Propiedad> lista = new List<Propiedad>();

            using (var conn = new SqlConnection(conexion))
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_propiedades", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        lista.Add(new Propiedad
                        {
                            IDPropiedad = Convert.ToInt32(reader["IDPropiedad"]),
                            TerrenoM2 = Convert.ToInt32(reader["TerrenoM2"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            CantCuartos = Convert.ToInt16(reader["CantCuartos"]),
                            CantBanhos = Convert.ToInt16(reader["CantBanhos"]),
                            CantDormitorios = Convert.ToInt16(reader["CantDormitorios"]),
                            NotasExtra = reader["NotasExtra"].ToString(),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            FechaDeCompra = reader["FechaDeCompra"].ToString(),
                            IDDireccionPropiedadesP = Convert.ToInt32(reader["IDDireccionPropiedadesP"]),
                            IDEstatusPropiedadP = Convert.ToInt32(reader["IDEstatusPropiedadP"]),
                            IDPropietarioP = Convert.ToInt32(reader["IDPropietarioP"])

                        });
                    }
                }
            }
            return lista;
        }

        public async Task<Propiedad> Obtener(int id)
        {
            Propiedad objeto = new Propiedad();

            using (var conn = new SqlConnection(conexion))
            {
                await conn.OpenAsync();
                SqlCommand cmd = new SqlCommand("sp_obtenerpropiedades", conn);
                cmd.Parameters.AddWithValue("@IDPropiedad", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var reader = await cmd.ExecuteReaderAsync())
                {
                    while (await reader.ReadAsync())
                    {
                        objeto = new Propiedad
                        {
                            IDPropiedad = Convert.ToInt32(reader["IDPropiedad"]),
                            TerrenoM2 = Convert.ToInt32(reader["TerrenoM2"]),
                            Descripcion = reader["Descripcion"].ToString(),
                            CantCuartos = Convert.ToInt16(reader["CantCuartos"]),
                            CantBanhos = Convert.ToInt16(reader["CantBanhos"]),
                            CantDormitorios = Convert.ToInt16(reader["CantDormitorios"]),
                            NotasExtra = reader["NotasExtra"].ToString(),
                            Precio = Convert.ToDecimal(reader["Precio"]),
                            FechaDeCompra = reader["FechaDeCompra"].ToString(),
                            IDDireccionPropiedadesP = Convert.ToInt32(reader["IDDireccionPropiedadesP"]),
                            IDEstatusPropiedadP = Convert.ToInt32(reader["IDEstatusPropiedadP"]),
                            IDPropietarioP = Convert.ToInt32(reader["IDPropietarioP"])

                        };
                    }
                }
            }
            return objeto;
        }

        public async Task<bool> Crear(Propiedad objeto)
        {
            bool respuesta = true;

            using (var conn = new SqlConnection(conexion))
            {
                
                SqlCommand cmd = new SqlCommand("sp_crearpropiedades", conn);
                cmd.Parameters.AddWithValue("@TerrenoM2", objeto.TerrenoM2);
                cmd.Parameters.AddWithValue("@Descripcion", objeto.Descripcion);
                cmd.Parameters.AddWithValue("@CantCuartos", objeto.CantCuartos);
                cmd.Parameters.AddWithValue("@CantBanhos", objeto.CantBanhos);
                cmd.Parameters.AddWithValue("@CantDormitorios", objeto.CantDormitorios);
                cmd.Parameters.AddWithValue("@NotasExtra", objeto.NotasExtra);
                cmd.Parameters.AddWithValue("@Precio", objeto.Precio);
                cmd.Parameters.AddWithValue("@FechaDeCompra", objeto.FechaDeCompra);
                cmd.Parameters.AddWithValue("@IDDireccionPropiedadesP", objeto.IDDireccionPropiedadesP);
                cmd.Parameters.AddWithValue("@IDEstatusPropiedadP", objeto.IDEstatusPropiedadP);
                cmd.Parameters.AddWithValue("@IDPropietarioP", objeto.IDPropietarioP);
                cmd.CommandType = CommandType.StoredProcedure;

                try 
                {
                    await conn.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true:false ;
                } 
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public async Task<bool> Editar(Propiedad objeto)
        {
            bool respuesta = true;

            using (var conn = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("sp_editarpropiedades", conn);
                cmd.Parameters.AddWithValue("@IDPropiedad", objeto.IDPropiedad);
                cmd.Parameters.AddWithValue("@TerrenoM2", objeto.TerrenoM2);
                cmd.Parameters.AddWithValue("@Descripcion", objeto.Descripcion);
                cmd.Parameters.AddWithValue("@CantCuartos", objeto.CantCuartos);
                cmd.Parameters.AddWithValue("@CantBanhos", objeto.CantBanhos);
                cmd.Parameters.AddWithValue("@CantDormitorios", objeto.CantDormitorios);
                cmd.Parameters.AddWithValue("@NotasExtra", objeto.NotasExtra);
                cmd.Parameters.AddWithValue("@Precio", objeto.Precio);
                cmd.Parameters.AddWithValue("@FechaDeCompra", objeto.FechaDeCompra);
                cmd.Parameters.AddWithValue("@IDDireccionPropiedadesP", objeto.IDDireccionPropiedadesP);
                cmd.Parameters.AddWithValue("@IDEstatusPropiedadP", objeto.IDEstatusPropiedadP);
                cmd.Parameters.AddWithValue("@IDPropietarioP", objeto.IDPropietarioP);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await conn.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }

        public async Task<bool> Eliminar(int id)
        {
            bool respuesta = true;

            using (var conn = new SqlConnection(conexion))
            {

                SqlCommand cmd = new SqlCommand("sp_eliminarpropiedades", conn);
                cmd.Parameters.AddWithValue("@IDPropiedad", id);
                cmd.CommandType = CommandType.StoredProcedure;

                try
                {
                    await conn.OpenAsync();
                    respuesta = await cmd.ExecuteNonQueryAsync() > 0 ? true : false;
                }
                catch
                {
                    respuesta = false;
                }
            }
            return respuesta;
        }
    }
}
