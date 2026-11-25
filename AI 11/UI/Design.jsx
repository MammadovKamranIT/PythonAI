
import React, { useState } from "react";
import "./Design.css";


export default function PricePredictor() {
    const [form, setForm] = useState({
        city: "",
        area: "",
        bedrooms: "",
        bathrooms: "",
    });

    const [price, setPrice] = useState(null);

    const handleChange = (e) => {
        setForm({
            ...form,
            [e.target.name]: e.target.value,
        });
        setPrice(null);
    };

    const handlePredict = async (e) => {
        e.preventDefault();

        // Replace with your ML backend API
        const response = await fetch("http://localhost:5157/api/values", {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
            },
            body: JSON.stringify(form),
        });

        const data = await response.json();
        setPrice(data.priceAZN);
    };

    return (
        <div className="predictor-page">
            <div className="predictor-card">
                <div className="logo">⌂ EstatePredict</div>

                <h1>Property Price Predictor</h1>
                <p className="subtitle">
                    Discover your property's estimated market value.
                </p>

                <form onSubmit={handlePredict}>
                    <label>City</label>
                    <input
                        name="city"
                        placeholder="Enter city"
                        value={form.city}
                        onChange={handleChange}
                        required
                    />

                    <label>Square meters (m²)</label>
                    <input
                        type="number"
                        name="area"
                        placeholder="e.g. 120"
                        value={form.area}
                        onChange={handleChange}
                        min="1"
                        required
                    />

                    <div className="input-row">
                        <div>
                            <label>Bedrooms</label>
                            <input
                                type="number"
                                name="bedrooms"
                                placeholder="3"
                                value={form.bedrooms}
                                onChange={handleChange}
                                min="0"
                                required
                            />
                        </div>

                        <div>
                            <label>Bathrooms</label>
                            <input
                                type="number"
                                name="bathrooms"
                                placeholder="2"
                                value={form.bathrooms}
                                onChange={handleChange}
                                min="0"
                                required
                            />
                        </div>
                    </div>

                    <button type="submit">
                        ✨ Predict Price
                    </button>
                </form>

                {price !== null && (
                    <div className="result">
                        <p>Estimated Property Value</p>
                        <h2>{Number(price).toLocaleString()} AZN</h2>
                    </div>
                )}
            </div>
        </div>
    );
}
