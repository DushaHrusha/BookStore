import Card from "antd/es/card/Card"
import { CardTitle } from "./Cardtitle"
import Button from "antd/es/button/button"

interface Props{
    books:Book[]
}

export const Books = ({books}:Props)=>{
    return(
        <div className="cards">
            {books.map((book:Book) =>(
                <Card 
                    key={book.id} title={<CardTitle title={book.title} price={book.price}/>}
                    bordered = {false}
                >
                    <p>{book.description}</p>
                    <div className="card_button">
                        <Button>
                            Edit
                        </Button>
                        <Button>
                            Delete
                        </Button>
                    </div>
                </Card>
            ))}
        </div>
    )
}