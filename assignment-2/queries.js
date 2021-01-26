const Pool = require('pg').Pool
const pool = new Pool({
  user: 'postgres',
  host: 'localhost',
  database: 'Assignment2',
  password: 'hetvi',
  port: 5432,
})


const getCars = (request, response) => {
  pool.query('SELECT c.id,c.name, m.makename,mo.modelname FROM car c inner join make m on c.makeid = m.makeid inner join model mo on c.modelid = mo.modelid', (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}


const getCarsById = (request, response) => {
  const id = parseInt(request.params.id)

  pool.query('SELECT c.id,c.name, m.makename,mo.modelname FROM car c inner join make m on c.makeid = m.makeid inner join model mo on c.modelid = mo.modelid WHERE c.id = $1', [id], (error, results) => {
    if (error) {
      throw error
    }
    response.status(200).json(results.rows)
  })
}

module.exports = {
    getCars,
    getCarsById,
 
}
