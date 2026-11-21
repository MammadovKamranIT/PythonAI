const API = "http://localhost:5157";

export type PredictIn = {

    bedrooms: number;
    bathrooms: number;
    sqm: number;
    city: string;



}



export async function predict (data: PredictIn) {

    const response = await fetch(`${API}/AI`,   {


        method: "POST",
        headers: {

        "Content-Type": "application/json",

        },

        body: JSON.stringify(data),


    })

    if (!response.ok) {

        throw new Error (`Http status ${response.status} with status ${response.statusText}`);

    }

    return response.json() as Promise <{priceAZN:number}>;


}
