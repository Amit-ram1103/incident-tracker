import { useEffect, useState } from "react";
import api from "../services/api";
import { useNavigate } from "react-router-dom";

export default function IncidentList() {
  const navigate = useNavigate();

  const [incidents, setIncidents] = useState([]);
  const [page, setPage] = useState(1);
  const [total, setTotal] = useState(0);

  const [search, setSearch] = useState("");
  const [status, setStatus] = useState("");

  const [service, setService] = useState("");
  const [severity, setSeverity] = useState("");

  const pageSize = 10;

  useEffect(() => {
    fetchData();
  }, [page, search, status, service, severity]);

  const fetchData = async () => {
    const res = await api.get("/incidents", {
      params: { page, pageSize, search, status, service, severity }
    });

    setIncidents(res.data.data);
    setTotal(res.data.total);
  };

  const totalPages = Math.ceil(total / pageSize);

  return (
    <div className="container">
      <div className="header">Incident Tracker</div>

      <div className="card">
        {/* Filters */}
        <div className="row">
          <input
            placeholder="Search..."
            value={search}
            onChange={e => setSearch(e.target.value)}
          />

          <select onChange={e => setService(e.target.value)}>
            <option value="">All Services</option>
            <option value="Payments">Payments</option>
            <option value="Orders">Orders</option>
            <option value="Auth">Auth</option>
          </select>

          <select onChange={e => setStatus(e.target.value)}>
            <option value="">All Status</option>
            <option value="OPEN">Open</option>
            <option value="MITIGATED">Mitigated</option>
            <option value="RESOLVED">Resolved</option>
          </select>

          <select onChange={e => setSeverity(e.target.value)}>
            <option value="">All Severity</option>
            <option value="SEV1">SEV1</option>
            <option value="SEV2">SEV2</option>
            <option value="SEV3">SEV3</option>
            <option value="SEV4">SEV4</option>
          </select>

          <button className="btn-primary" onClick={() => navigate("/create")}>
            New Incident
          </button>
        </div>

        {/* Table */}
        <table className="table">
          <thead>
            <tr>
              <th>Title</th>
              <th>Service</th>
              <th>Severity</th>
              <th>Status</th>
              <th>Owner</th>
              <th>Created</th>
            </tr>
          </thead>

          <tbody>
            {incidents.map(i => (
              <tr key={i.id} onClick={() => navigate(`/incidents/${i.id}`)}>
                <td>{i.title}</td>
                <td>{i.service}</td>
                <td>{i.severity}</td>
                <td>{i.status}</td>
                <td>{i.owner || "-"}</td>
                <td>{new Date(i.createdAt).toLocaleDateString()}</td>
              </tr>
            ))}
          </tbody>
        </table>

        {/* Pagination */}
        <div className="pagination">
          <button
            disabled={page === 1}
            onClick={() => setPage(p => p - 1)}
          >
            Prev
          </button>

          <span>Page {page} of {totalPages}</span>

          <button
            disabled={page === totalPages}
            onClick={() => setPage(p => p + 1)}
          >
            Next
          </button>
        </div>
      </div>
    </div>
  );
}