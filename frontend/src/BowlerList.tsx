import { useEffect, useState } from 'react';
import { oneBowler } from './types/oneBowler';

function BowlerList() {
  const [bowlers, setBowlers] = useState<oneBowler[]>([]);

  useEffect(() => {
    const getBowlers = async () => {
      const response = await fetch('https://localhost:44302/Bowlers/teams');
      const data = await response.json();
      setBowlers(data);
    };
    getBowlers();
  }, []);

  return (
    <div className="row ">
      <div className="col-10 mx-auto">
        <table className="table table-bordered table-light table-responsive table-striped table-hover">
          <thead className="thead-dark border-1">
            <th className="border-1 text-center">Bowler Name</th>
            <th className="border-1 text-center">Team Name</th>
            <th className="border-1 text-center">Address</th>
            <th className="border-1 text-center">City</th>
            <th className="border-1 text-center">State</th>
            <th className="border-1 text-center">Zip</th>
            <th className="border-1 text-center">Phone</th>
          </thead>
          <tbody>
            {bowlers.map((bowler) => (
              <tr>
                <td>{bowler.bowlerName}</td>
                <td>{bowler.teamName}</td>
                <td>{bowler.address}</td>
                <td>{bowler.city}</td>
                <td>{bowler.state}</td>
                <td>{bowler.zip}</td>
                <td>{bowler.phoneNumber}</td>
              </tr>
            ))}
          </tbody>
        </table>
      </div>
    </div>
  );
}

export default BowlerList;
