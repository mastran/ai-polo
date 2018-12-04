import asyncio

# IP-address of the hololens we are communicating.
SERVER_IP = "129.21.71.17"


async def send_message(message, loop):
    reader, writer = await asyncio.open_connection(SERVER_IP, 9090, loop=loop)

    print('Send: %r' % message)
    writer.write(message.encode())

    data = await reader.read(100)
    print('Received: %r' % data.decode())
    writer.close()


def send_command(command):
    message = "{:30s}".format(command)

    loop = asyncio.get_event_loop()
    loop.run_until_complete(send_message(message, loop))
    #loop.close()


if __name__ == '__main__':
    import sys
    send_command(sys.argv[1])