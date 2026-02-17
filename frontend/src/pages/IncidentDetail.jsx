import { useEffect, useState } from "react";
import api from "../services/api";
import { useParams, useNavigate } from "react-router-dom";

export default function IncidentDetail() {
  const { id } = useParams();
  const navigate = useNavigate();

  const [incident, setIncident] = useState(null);

  useEffect(() => {
    fetchIncident();
  }, []);

  const fetchIncident = async () => {
    const res = await api.get(`/incidents/${id}`);
    setIncident(res.data);
  };

  const handleChange = (field, value) => {
    setIncident(prev => ({ ...prev, [field]: value }));
  };

  const saveChanges = async () => {
    await api.patch(`/incidents/${id}`, {
      status: incident.status,
      owner: incident.owner,
      summary: incident.summary
    });

    alert("Updated successfully");
  };

  if (!incident) return <div className="container">Loading...</div>;

  return (
    <div className="container">
      <div className="header">Incident Detail</div>

      <div className="card">
        <div className="row">
          <b>Title:</b> {incident.title}
        </div>

        <div className="row">
          <b>Service:</b> {incident.service}
        </div>

        <div className="row">
          <b>Severity:</b> {incident.severity}
        </div>

        <div className="row">
          <label>Status</label>
          <select
            value={incident.status}
            onChange={e => handleChange("status", e.target.value)}
          >
            <option value="OPEN">Open</option>
            <option value="MITIGATED">Mitigated</option>
            <option value="RESOLVED">Resolved</option>
          </select>
        </div>

        <div className="row">
          <label>Owner</label>
          <input
            value={incident.owner || ""}
            onChange={e => handleChange("owner", e.target.value)}
          />
        </div>

        <div className="row">
          <label>Summary</label>
          <textarea
            value={incident.summary || ""}
            onChange={e => handleChange("summary", e.target.value)}
          />
        </div>

        <div className="row">
          <button className="btn-primary" onClick={saveChanges}>
            Save Changes
          </button>

          <button className="btn-secondary" onClick={() => navigate("/")}>
            Close
          </button>
        </div>
      </div>
    </div>
  );
}