import { useState } from "react";
import api from "../services/api";
import { useNavigate } from "react-router-dom";

export default function CreateIncident() {
  const navigate = useNavigate();

  const [form, setForm] = useState({
    title: "",
    service: "",
    severity: "SEV3",
    status: "OPEN",
    owner: "",
    summary: ""
  });

  const handleSubmit = async () => {
    await api.post("/incidents", form);
    navigate("/");
  };

  return (
    <div className="container">
      <div className="header">Create Incident</div>

      <div className="card">
        <div className="row">
          <input
            placeholder="Title"
            onChange={e => setForm({ ...form, title: e.target.value })}
          />
        </div>

        <div className="row">
          <select onChange={e => setForm({ ...form, service: e.target.value })}>
            <option value="">Select Service</option>
            <option value="Payments">Payments</option>
            <option value="Orders">Orders</option>
            <option value="Auth">Auth</option>
          </select>
        </div>

        <div className="row">
          <select onChange={e => setForm({ ...form, severity: e.target.value })}>
            <option value="SEV1">SEV1</option>
            <option value="SEV2">SEV2</option>
            <option value="SEV3">SEV3</option>
            <option value="SEV4">SEV4</option>
          </select>
        </div>

        <div className="row">
          <select onChange={e => setForm({ ...form, status: e.target.value })}>
            <option value="OPEN">Open</option>
            <option value="MITIGATED">Mitigated</option>
            <option value="RESOLVED">Resolved</option>
          </select>
        </div>

        <div className="row">
          <input
            placeholder="Owner"
            onChange={e => setForm({ ...form, owner: e.target.value })}
          />
        </div>

        <div className="row">
          <textarea
            placeholder="Summary"
            onChange={e => setForm({ ...form, summary: e.target.value })}
          />
        </div>

        <div className="row">
          <button className="btn-primary" onClick={handleSubmit}>
            Create Incident
          </button>

          <button className="btn-secondary" onClick={() => navigate("/")}>
            Close
          </button>
        </div>
      </div>
    </div>
  );
}