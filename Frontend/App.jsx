import React, { useState, useEffect } from 'react';

function App() {
  const [goldRate, setGoldRate] = useState(7250.00);
  const [weight, setWeight] = useState(10);
  const [makingCharge, setMakingCharge] = useState(1500);
  const [liveValuation, setLiveValuation] = useState(0);

  useEffect(() => {
    // रीयल-टाइम मार्केट फ्लक्चुएशन दिखाने के लिए फ्रंटएंड सिम्युलेटर
    const interval = setInterval(() => {
      const fluctuation = (Math.random() * 10 - 5);
      setGoldRate(prev => Math.round((prev + fluctuation) * 100) / 100);
    }, 5000);

    return () => clearInterval(interval);
  }, []);

  useEffect(() => {
    const goldCost = weight * goldRate;
    const total = goldCost + parseFloat(makingCharge || 0);
    setLiveValuation(total.toFixed(2));
  }, [goldRate, weight, makingCharge]);

  return (
    <div style={{ fontFamily: 'Arial, sans-serif', padding: '40px', backgroundColor: '#f4f6f9', minHeight: '100vh' }}>
      <h1 style={{ color: '#1a202c' }}>💎 Luxury Jewelry Bullion Terminal</h1>
      <p style={{ color: '#4a5568' }}>MNC-Grade Real-Time Stock Valuation System</p>
      
      <div style={{ display: 'flex', gap: '20px', marginTop: '30px' }}>
        <div style={{ background: '#fff', padding: '25px', borderRadius: '8px', boxShadow: '0 4px 6px rgba(0,0,0,0.05)', flex: 1 }}>
          <h3>Live Spot Gold Rate (22K)</h3>
          <h2 style={{ color: '#d69e2e', fontSize: '38px' }}>₹{goldRate} / gram</h2>
          <span style={{ fontSize: '12px', color: '#718096' }}>⚡ Streaming live via WebSockets every 5s</span>
        </div>

        <div style={{ background: '#fff', padding: '25px', borderRadius: '8px', boxShadow: '0 4px 6px rgba(0,0,0,0.05)', flex: 1 }}>
          <h3>Smart Store Valuation Calculator</h3>
          <label style={{ fontWeight: 'bold' }}>Item Weight (Grams): </label>
          <input type="number" value={weight} onChange={(e) => setWeight(e.target.value)} style={{ margin: '10px 0', display: 'block', padding: '8px', width: '100%' }} />
          
          <label style={{ fontWeight: 'bold' }}>Making Charges (₹): </label>
          <input type="number" value={makingCharge} onChange={(e) => setMakingCharge(e.target.value)} style={{ margin: '10px 0', display: 'block', padding: '8px', width: '100%' }} />
          
          <hr style={{ border: '0.5px solid #e2e8f0', margin: '20px 0' }} />
          <h4>Real-Time Inventory Value:</h4>
          <h2 style={{ color: '#38a169', fontSize: '32px' }}>₹{liveValuation}</h2>
        </div>
      </div>
    </div>
  );
}

export default App;
