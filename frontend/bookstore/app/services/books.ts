export interface BookRequest{
    title: string;
    description:string;
    price:number;
}

export const getAllBooks = async ()=>{
    const response = await fetch("http://localhost:5079/Books")
    return response.json();
}

1 08