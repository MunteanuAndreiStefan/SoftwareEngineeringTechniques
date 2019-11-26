import functools
import logging
logger = logging.getLogger('decorator-log')
logger.setLevel(logging.DEBUG)

# create console handler and set level to debug
ch = logging.FileHandler('log.txt')
ch.setLevel(logging.DEBUG)

# create formatter
formatter = logging.Formatter('%(asctime)s - %(name)s - %(levelname)s - %(message)s')

# add formatter to ch
ch.setFormatter(formatter)

# add ch to logger
logger.addHandler(ch)

class LogDecorator(object):
    indent = 0

    def __init__(self):
        self.logger = logging.getLogger('decorator-log')

    def __call__(self, fn):
        @functools.wraps(fn)
        def decorated(*args, **kwargs):
            try:
                self.logger.debug("START {0} - {1} - {2} - {3}".format(fn.__name__, ' '*self.indent, args, kwargs))
                self.indent += 1
                result = fn(*args, **kwargs)
                self.logger.debug("END   {0} - {1} - {2}".format(fn.__name__, ' '*self.indent, result))
                self.indent -= 1
                return result
            except Exception as ex:
                self.logger.debug("Exception {0}".format(ex))
                raise ex
            return result
        return decorated
