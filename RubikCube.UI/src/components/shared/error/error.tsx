export default function Error({ message }: { message: string | null}) {
    return (<div className={message !== null ? "error" : "error hidden"}>
        <p>Error: {message}</p>
    </div>);
}