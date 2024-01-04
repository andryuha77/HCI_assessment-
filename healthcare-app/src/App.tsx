import React, { useState, useEffect } from 'react';
import axios, { AxiosError } from 'axios';
import './App.css';

interface Patient {
  id: number;
  name: string;
}

interface Visit {
  visitID: number;
  patientID: number;
  hospitalID: number;
  visitDate: string;
}

function App() {
  const [searchTerm, setSearchTerm] = useState<string>('');
  const [allPatients, setAllPatients] = useState<Patient[]>([]);
  const [searchResults, setSearchResults] = useState<Patient[]>([]);
  const [visitData, setVisitData] = useState<Visit[]>([]);
  const [loading, setLoading] = useState<boolean>(false);
  const [error, setError] = useState<string | null>(null);

  useEffect(() => {
    fetchData();
  }, []);

  const handleSearch = async () => {
    try {
      setLoading(true);
  
      const response = await axios.get(`https://localhost:44379/api/Patients`);
      const allPatients: Patient[] = response.data;
  
      // Filter patients based on the search term
      const filteredPatients = allPatients.filter(patient =>
        patient.name.toLowerCase().includes(searchTerm.toLowerCase())
      );
  
      // Set the filtered results in the state
      setSearchResults(filteredPatients);
  
      if (filteredPatients.length > 0) {
        const firstPatientId = filteredPatients[0].id;
  
        // Only make the visit API call if there is a search term
        if (searchTerm.trim() !== '') {
          const visitResponse = await axios.get(`https://localhost:44379/api/Patients/${firstPatientId}/Visits`);
          const visitData: Visit[] = visitResponse.data;
  
          // Set the visit data in the state
          setVisitData(visitData);
          console.log('Visits related to the patient:', visitData);
        } else {
          setVisitData([]);
        }
      } else {
        setVisitData([]);
      }
    } catch (error: unknown) {
      if (axios.isAxiosError(error) && (error as AxiosError).response === undefined) {
        setError('Network Error. Please check your connection.');
      } else {
        setError(`Error fetching data. Status: ${(error as AxiosError).response?.status || 'Unknown'}`);
      }
      console.error('Error fetching data:', error);
    } finally {
      setLoading(false);
    }
  };
  
  const fetchData = async () => {
    try {
      setLoading(true);
      const response = await axios.get('https://localhost:44379/api/Patients');
      const initialData: Patient[] = response.data;
      
      setAllPatients(initialData);
    } catch (error) {
      setError('Error fetching initial data. Please try again.');
      console.error('Error fetching initial data:', error);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="App">
      <h1>Healthcare Information System</h1>
      <div>
        <input
          type="text"
          placeholder="Enter patient full name"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
        <button onClick={handleSearch} disabled={loading}>
          {loading ? 'Searching...' : 'Search'}
        </button>
      </div>

      {error && <div style={{ color: 'red' }}>{error}</div>}

        {visitData.length > 0 && (
        <div>
          <h2>Visit Information:</h2>
          <ul style={{ listStyle: 'none', padding: 0 }}>
            {visitData.map((visit) => (
              <li key={visit.visitID}>
                {/* Display relevant information about the visit */}
                Visit ID: {visit.visitID}, Patient ID: {visit.patientID}, Hospital ID: {visit.hospitalID}, Visit Date: {visit.visitDate}
              </li>
            ))}
          </ul>
        </div>
      )}

      <div>
        <h2>All Patients:</h2>
        <ul style={{ listStyle: 'none', padding: 0 }}>
          {allPatients.map((patient) => (
            <li key={patient.id}>
              Patient ID: {patient.id}, Name: {patient.name}
            </li>
          ))}
        </ul>
    </div>

    </div>
  );
}

export default App;
